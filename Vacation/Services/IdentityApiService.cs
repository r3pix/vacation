using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vacation.Interfaces;
using Vacation.Models.Identity;
using Vacation.Services;

namespace Vacation.Services
{
    public class IdentityApiService : BaseApiService, IIdentityApiService
    {
        private readonly IActionContextAccessor _actionContextAccessor;

        public IdentityApiService(
            HttpClient httpClient,
            IMapper mapper,
            IActionContextAccessor actionContextAccessor
            ) : base(httpClient, mapper)
        {
            _actionContextAccessor = actionContextAccessor;
            AddAuthTokenToClient();
        }

        public async Task<bool> CheckIfExistsAsync(string nip) =>
            (await GetAsync(nip)) != null;

        public async Task CreateUser(IdentityUserModel person)
        {
            var json = JsonConvert.SerializeObject(person);
            await AddOrUpdateUser(json);
        }

        public async Task<bool> DeleteUser(string email)
        {
            var deserialized = new bool();

            var response = await _httpClient.GetAsync($"DeleteUser?email={email}");
            if (response.IsSuccessStatusCode)
            {
                deserialized = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
            }
            return deserialized;
        }

        public async Task GeneratePasswordResetEmail(string email)
        {
            var response = await _httpClient.PostAsync($"SendPasswordResetMail?userName={email}", null);
            if (!response.IsSuccessStatusCode)
            {
                var err = response.Content.ReadAsStringAsync();
                //var content = JsonConvert.DeserializeObject<IdentityApiServiceErrorResponseModel>(await response.Content.ReadAsStringAsync());
                //throw new Exception(content.Errors.First());
                throw new Exception("Error while sending email");
            }
        }

        public async Task<object> GetAsync(string email)
        {
            var deserialized = new IdentityApiServiceResponseModel();
            var response = await _httpClient.GetAsync($"email-unique?email={email}");

            if (response.IsSuccessStatusCode)
            {
                deserialized = JsonConvert.DeserializeObject<IdentityApiServiceResponseModel>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
            }

            var result = _mapper.Map<object>(deserialized);
            return result;
        }

        public async Task<string> GetPasswordResetToken(Guid id)
        {
            string token = null;

            var response = await _httpClient.GetAsync($"GetPasswordResetToken?userId={id}");
            if (response.IsSuccessStatusCode)
            {
                token = await response.Content.ReadAsStringAsync();
                //token = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
            }
            return token;
        }

        public async Task<UserModel> GetUser(Guid id)
        {
            var deserialized = new UserModel();

            var response = await _httpClient.GetAsync($"GetUser?userId={id}");
            if (response.IsSuccessStatusCode)
            {
                deserialized = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
            }
            return deserialized;
        }

        public async Task<bool> IsEmailUsed(string email)
        {
            var deserialized = false;
            var response = await _httpClient.GetAsync($"email-unique?email={email}");
            if (response.IsSuccessStatusCode)
            {
                deserialized = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
            }
            return deserialized;
        }

        public async Task<Guid> ResetPassword(ResetPasswordModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"ResetPasswordByEmail", data);

            var deserialized = JsonConvert.DeserializeObject<Guid>(await response.Content.ReadAsStringAsync());
            return deserialized;
        }

        public async Task<bool> UpdatePassword(string userId, string currentPassword, string newPassword)
        {
            var json = JsonConvert.SerializeObject(new { Id = userId, CurrentPassword = currentPassword, NewPassword = newPassword });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"ChangePasswordById", data);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            var result = await response.Content.ReadAsStringAsync();
            var errors = JsonConvert.DeserializeObject<IEnumerable<IdentityError>>(result);

            throw IdentityException.FromErrors(errors);
        }

        public async Task UpdateUser(IdentityUpdateUserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _actionContextAccessor.ActionContext.HttpContext.GetTokenAsync("access_token"));

            var response = await _httpClient.PostAsync($"UpdateUser", data);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        private async void AddAuthTokenToClient()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _actionContextAccessor.ActionContext.HttpContext.GetTokenAsync("access_token"));
        }

        private async Task AddOrUpdateUser(string json)
        {
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _actionContextAccessor.ActionContext.HttpContext.GetTokenAsync("access_token"));

            var response = await _httpClient.PostAsync($"CreateOrUpdateUser", data);
            
            if (!response.IsSuccessStatusCode)
            {
                var content = JsonConvert.DeserializeObject<IdentityApiServiceErrorResponseModel>(await response.Content.ReadAsStringAsync());
                throw new Exception(content.Errors.First());
            }
        }
    }
}
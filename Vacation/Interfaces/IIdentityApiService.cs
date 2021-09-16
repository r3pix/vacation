
using System;
using System.Threading.Tasks;
using Vacation.Models.Identity;

namespace Vacation.Interfaces
{
    public interface IIdentityApiService
    {
        Task CreateUser(IdentityUserModel user);

        Task<bool> DeleteUser(string email);

        Task GeneratePasswordResetEmail(string email);

        Task<UserModel> GetUser(Guid id);

        Task<bool> IsEmailUsed(string email);

        Task<Guid> ResetPassword(ResetPasswordModel model);

        Task<bool> UpdatePassword(string userName, string currentPassword, string newPassword);

        Task UpdateUser(IdentityUpdateUserModel user);
    }
}
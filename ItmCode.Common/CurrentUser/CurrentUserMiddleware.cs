using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ItmCode.Common.CurrentUser
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentUser currentUser)
        {
            currentUser.SetCurrentUser(context.User.Claims);

            await _next.Invoke(context);
        }
    }
}
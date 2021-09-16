using ItmCode.Common.CurrentUser;
using Microsoft.AspNetCore.Builder;


namespace ItmCode.Common.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app) =>
             app.UseMiddleware<CurrentUserMiddleware>();

        //public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        //            => app.UseMiddleware<ExceptionsMiddleware>();
    }
}

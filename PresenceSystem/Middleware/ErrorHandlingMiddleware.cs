using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Vacation.Exceptions;

namespace Vacation.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException bad)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(bad.Message);
            }
            catch (NotFoundException not)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(not.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
           
        }
    }
}

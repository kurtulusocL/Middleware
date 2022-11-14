using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.Middlewares
{
    public class UseAuthorizeCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        public UseAuthorizeCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/product" && context.Request.Method == "POST" && !context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("You are not authorized");
            }
            await _next(context);
        }
    }
}

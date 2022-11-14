using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.Middlewares
{
    public class UseCategoryMiddleware
    {
        private readonly RequestDelegate _next;
        public UseCategoryMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Items["value"] != null)
            {
                var value = context.Items["value"].ToString();
                await context.Response.WriteAsync($"category: {value}");
            }
            else
            {
                await context.Response.WriteAsync("no value");
            }
        }
    }
}

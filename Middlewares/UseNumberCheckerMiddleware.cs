using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.Middlewares
{
    public class UseNumberCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        public UseNumberCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/product")
            {
                var value = context.Request.Query["category"].ToString();
                if (int.TryParse(value, out int intvalue))
                {
                    await context.Response.WriteAsync($"category is a number: {intvalue}");
                }
                else
                {
                    context.Items["value"] = value;
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}

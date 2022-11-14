using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.Middlewares
{
    public class UseUpperCaseMiddleware
    {
        private readonly RequestDelegate _next;
        public UseUpperCaseMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Items["value"] != null)
            {
                var value = context.Items["value"].ToString();
                context.Items["value"] = value.ToUpper();
            }
            await _next(context);
        }
    }
}

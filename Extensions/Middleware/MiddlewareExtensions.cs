using Microsoft.AspNetCore.Builder;
using Middleware.Middlewares;

namespace Middleware.Extensions.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseNumberCheckerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UseNumberCheckerMiddleware>();
        }

        public static IApplicationBuilder UseUpperCaseMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UseUpperCaseMiddleware>();
        }

        public static IApplicationBuilder UseCategoryMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UseCategoryMiddleware>();
        }
        public static IApplicationBuilder UseAuthorizeCheckerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UseAuthorizeCheckerMiddleware>();
        }
    }
}

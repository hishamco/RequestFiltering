using Microsoft.AspNetCore.Builder;
using System;

namespace RequestFiltering
{
    public static class RequestFilteringMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestFiltering(this IApplicationBuilder app, RequestFilteringOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<RequestFilteringMiddleware>(options);
        }
    }
}

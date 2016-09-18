using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RequestFiltering
{
    public class RequestFilteringMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestFilteringOptions _options;

        public RequestFilteringMiddleware(
            RequestDelegate next,
            RequestFilteringOptions options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _next = next;
            _options = options;
        }

        public Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var requestFilteringContext = new RequestFilteringContext
            {
                HttpContext = context,
                Result = RequestFilteringResult.Continue
            };

            foreach (var filter in _options.Filters)
            {
                filter.ApplyFilter(requestFilteringContext);

                switch (requestFilteringContext.Result)
                {
                    case RequestFilteringResult.Continue:
                        break;
                    case RequestFilteringResult.StopFilters:
                        return Task.FromResult(0);
                    default:
                        throw new ArgumentOutOfRangeException($"Invalid filter termination {requestFilteringContext.Result}");
                }
            }

            return _next(context);
        }
    }
}

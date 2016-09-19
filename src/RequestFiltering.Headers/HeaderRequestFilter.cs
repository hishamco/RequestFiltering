using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;

namespace RequestFiltering.Headers
{
    public class HeaderRequestFilter : RequestFilter<HeadersOptions>
    {
        public HeaderRequestFilter() : this(new HeadersOptions())
        {

        }

        public HeaderRequestFilter(HeadersOptions options)
        {
            Options = options;
        }

        public override HeadersOptions Options { get; }

        public override void ApplyFilter(RequestFilteringContext context)
        {
            if (Options.MaxAllowedContentLength < context.HttpContext.Request.ContentLength)
            {
                context.HttpContext.Response.StatusCode = 404;
                context.Result = RequestFilteringResult.StopFilters;
            }

            if (Options.MaxQueryString < context.HttpContext.Request.QueryString.Value.Length)
            {
                context.HttpContext.Response.StatusCode = 404;
                context.Result = RequestFilteringResult.StopFilters;
            }

            if (Options.MaxUrl < context.HttpContext.Request.GetDisplayUrl().Length)
            {
                context.HttpContext.Response.StatusCode = 404;
                context.Result = RequestFilteringResult.StopFilters;
            }

            Options.HeadersCollection.ToList().ForEach(header =>
            {
                if (context.HttpContext.Request.Headers.Keys.Contains(header.Header) && context.HttpContext.Request.Headers[header.Header].ToString().LongCount() > header.SizeLimit)
                {
                    context.HttpContext.Response.StatusCode = 404;
                    context.Result = RequestFilteringResult.StopFilters;
                    return;
                }
            });

            context.Result = RequestFilteringResult.Continue;
        }
    }
}

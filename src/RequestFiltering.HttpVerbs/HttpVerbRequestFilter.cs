using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestFiltering.HttpVerbs
{
    public class HttpVerbRequestFilter : RequestFilter<HttpVerbsOptions>
    {
        public HttpVerbRequestFilter() : this(new HttpVerbsOptions())
        {

        }

        public HttpVerbRequestFilter(HttpVerbsOptions options)
        {
            Options = options;
        }

        public override HttpVerbsOptions Options { get; }

        public override void ApplyFilter(RequestFilteringContext context)
        {
            var verb = context.HttpContext.Request.Method;

            if (Options.AllowUnlisted)
            {
                if (Options.HttpVerbsCollection.Any(v => v.Verb.ToString().Equals(verb, StringComparison.OrdinalIgnoreCase) && v.Allowed == false))
                {
                    context.HttpContext.Response.StatusCode = 404;
                    context.Result = RequestFilteringResult.StopFilters;
                    return;
                }

                context.Result = RequestFilteringResult.Continue;
            }
            else
            {
                if (Options.HttpVerbsCollection.Any(v => v.Verb.ToString().Equals(verb, StringComparison.OrdinalIgnoreCase) && v.Allowed == true))
                {
                    context.Result = RequestFilteringResult.Continue;
                    return;
                }

                context.HttpContext.Response.StatusCode = 404;
                context.Result = RequestFilteringResult.StopFilters;
            }
        }
    }
}

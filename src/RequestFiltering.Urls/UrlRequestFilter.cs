using System.Linq;

namespace RequestFiltering.Urls
{
    public class UrlRequestFilter : RequestFilter<UrlsOptions>
    {
        public UrlRequestFilter() : this(new UrlsOptions())
        {

        }

        public UrlRequestFilter(UrlsOptions options)
        {
            Options = options;
        }

        public override UrlsOptions Options { get; }

        public override void ApplyFilter(RequestFilteringContext context)
        {
            var url = context.HttpContext.Request.Path.Value;

            if (Options.AllowedUrls.Contains(url))
            {
                context.Result = RequestFilteringResult.Continue;
            }
            else
            {
                Options.DeniedUrlSequences.ToList().ForEach(s =>
                {
                    if (url.Contains(s))
                    {
                        context.HttpContext.Response.StatusCode = 404;
                        context.Result = RequestFilteringResult.StopFilters;
                    }
                });
            }
        }
    }
}

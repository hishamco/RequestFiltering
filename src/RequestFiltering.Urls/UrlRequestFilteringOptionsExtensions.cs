using System;

namespace RequestFiltering.Urls
{
    public static class UrlRequestFilteringOptionsExtensions
    {
        public static RequestFilteringOptions AddUrlRequestFilter(this RequestFilteringOptions requestFilteringOptions, UrlsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var filter = new UrlRequestFilter(options);

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

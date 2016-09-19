using System;

namespace RequestFiltering.Headers
{
    public static class HeaderRequestFilteringOptionsExtensions
    {
        public static RequestFilteringOptions AddHeaderRequestFilter(this RequestFilteringOptions requestFilteringOptions, HeadersOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var filter = new HeaderRequestFilter(options);

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

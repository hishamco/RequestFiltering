using System;

namespace RequestFiltering.QueryStrings
{
    public static class QueryStringRequestFiltreingOptionsExtensions
    {
        public static RequestFilteringOptions AddQueryStringRequestFilter(this RequestFilteringOptions requestFilteringOptions, QueryStringsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var filter = new QueryStringRequestFilter(options);

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

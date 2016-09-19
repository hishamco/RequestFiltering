using System;

namespace RequestFiltering.HttpVerbs
{
    public static class HttpVerbRequestFilteringOptionsExtensions
    {
        public static RequestFilteringOptions AddHttpVerbRequestFilter(this RequestFilteringOptions requestFilteringOptions, HttpVerbsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var filter = new HttpVerbRequestFilter(options);

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

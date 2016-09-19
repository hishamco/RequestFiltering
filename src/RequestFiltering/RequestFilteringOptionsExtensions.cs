using System;

namespace RequestFiltering
{
    public static class RequestFilteringOptionsExtensions
    {
        public static RequestFilteringOptions AddRequestFilter(this RequestFilteringOptions requestFilteringOptions, IRequestFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

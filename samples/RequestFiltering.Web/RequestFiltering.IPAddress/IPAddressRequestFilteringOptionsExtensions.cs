using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestFiltering.IPAddress
{
    public static class IPAddressRequestFilteringOptionsExtensions
    {
        public static RequestFilteringOptions AddIPAddressRequestFilter(this RequestFilteringOptions requestFilteringOptions, IPAddressOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var filter = new IPAddressRequestFilter(options);

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

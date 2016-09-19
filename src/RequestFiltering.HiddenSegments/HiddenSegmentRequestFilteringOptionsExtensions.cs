using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestFiltering.HiddenSegments
{
    public static class HiddenSegmentRequestFilteringOptionsExtensions
    {
        public static RequestFilteringOptions AddHiddenSegmentRequestFilter(this RequestFilteringOptions requestFilteringOptions, HiddenSegmentsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var filter = new HiddenSegmentRequestFilter(options);

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

using System.Collections.Generic;

namespace RequestFiltering.HiddenSegments
{
    public class HiddenSegmentsOptions : IRequestFilterOptions
    {
        public IList<HiddenSegmentElement> HiddenSegmentsCollection { get; set; }
    }
}

using System.Collections.Generic;

namespace RequestFiltering.Headers
{
    public class HeadersOptions : IRequestFilterOptions
    {
        public long MaxAllowedContentLength { get; set; } = 30000000;

        public long MaxUrl { get; set; } = 4096;

        public long MaxQueryString { get; set; } = 2048;

        public IList<HeaderElement> HeadersCollection { get; set; } = new List<HeaderElement>();
    }
}

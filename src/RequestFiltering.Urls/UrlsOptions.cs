using System.Collections.Generic;

namespace RequestFiltering.Urls
{
    public class UrlsOptions : IRequestFilterOptions
    {
        public IList<string> AllowedUrls { get; set; }

        public IList<string> DeniedUrlSequences { get; set; }
    }
}

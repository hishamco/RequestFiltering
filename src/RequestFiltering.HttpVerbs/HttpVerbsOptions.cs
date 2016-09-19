using System.Collections.Generic;

namespace RequestFiltering.HttpVerbs
{
    public class HttpVerbsOptions : IRequestFilterOptions
    {
        public bool AllowUnlisted { get; set; } = true;

        public IList<HttpVerbElement> HttpVerbsCollection { get; set; }
    }
}

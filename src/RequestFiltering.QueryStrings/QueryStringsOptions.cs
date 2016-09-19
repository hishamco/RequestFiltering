using System.Collections.Generic;

namespace RequestFiltering.QueryStrings
{
    public class QueryStringsOptions : IRequestFilterOptions
    {
        public bool AllowUnlisted { get; set; } = true;

        public IList<QueryStringElement> QueryStringsCollection { get; set; } = new List<QueryStringElement>();
    }
}

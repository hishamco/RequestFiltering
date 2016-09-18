using System.Collections.Generic;

namespace RequestFiltering
{
    public class RequestFilteringOptions
    {
        public IList<IRequestFilter> Filters { get; } = new List<IRequestFilter>();
    }
}

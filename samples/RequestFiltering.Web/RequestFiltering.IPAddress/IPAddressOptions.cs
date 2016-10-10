using System.Collections.Generic;

namespace RequestFiltering.IPAddress
{
    public class IPAddressOptions : IRequestFilterOptions
    {
        public IList<string> IPAddresses { get; set; }
    }
}

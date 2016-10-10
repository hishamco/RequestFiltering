using System.Collections.Generic;

namespace RequestFiltering.SqlInjection
{
    public class SqlInjectionOptions : IRequestFilterOptions
    {
        public IList<string> DenyStrings { get; set; }
    }
}

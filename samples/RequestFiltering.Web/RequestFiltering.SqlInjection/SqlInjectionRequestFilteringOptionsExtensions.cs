using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestFiltering.SqlInjection
{
    public static class SqlInjectionRequestFilteringOptionsExtensions
    {
        public static RequestFilteringOptions AddSqlInjectionRequestFilter(this RequestFilteringOptions requestFilteringOptions)
        {
            var options = new SqlInjectionOptions()
            {
                DenyStrings = new []
                {
                    "--", ";", "/*", "@", "char", "alter", "begin",
                    "create", "cursor", "declare", "delete", "drop",
                    "end", "exec", "fetch", "insert", "kill", "open",
                    "select", "sys", "table", "update"
                }
            };
            var filter = new SqlInjectionRequestFilter(options);

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

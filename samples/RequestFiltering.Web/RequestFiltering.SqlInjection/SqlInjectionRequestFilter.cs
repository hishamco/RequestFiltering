using System.Linq;

namespace RequestFiltering.SqlInjection
{
    public class SqlInjectionRequestFilter : RequestFilter<SqlInjectionOptions>
    {
        public SqlInjectionRequestFilter() : this(new SqlInjectionOptions())
        {

        }

        public SqlInjectionRequestFilter(SqlInjectionOptions options)
        {
            Options = options;
        }

        public override SqlInjectionOptions Options { get; }

        public override void ApplyFilter(RequestFilteringContext context)
        {
            if (!context.HttpContext.Request.QueryString.HasValue)
            {
                context.Result = RequestFilteringResult.Continue;
                return;
            }

            if (Options.DenyStrings.Any(s => context.HttpContext.Request.QueryString.Value.Contains(s)))
            {
                context.HttpContext.Response.StatusCode = 404;
                context.Result = RequestFilteringResult.StopFilters;
                return;
            }

            context.Result = RequestFilteringResult.Continue;
        }
    }
}

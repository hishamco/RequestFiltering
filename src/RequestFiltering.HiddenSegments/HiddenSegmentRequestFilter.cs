using System;
using System.Linq;

namespace RequestFiltering.HiddenSegments
{
    public class HiddenSegmentRequestFilter : RequestFilter<HiddenSegmentsOptions>
    {
        public HiddenSegmentRequestFilter() : this(new HiddenSegmentsOptions())
        {

        }

        public HiddenSegmentRequestFilter(HiddenSegmentsOptions options)
        {
            Options = options;
        }

        public override HiddenSegmentsOptions Options { get; }

        public override void ApplyFilter(RequestFilteringContext context)
        {
            var path = context.HttpContext.Request.Path.Value;
            var segments = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length == 0)
            {
                context.Result = RequestFilteringResult.Continue;
                return;
            }

            if (Options.HiddenSegmentsCollection.Any(s => segments.Contains(s.Segment)))
            {
                context.HttpContext.Response.StatusCode = 404;
                context.Result = RequestFilteringResult.StopFilters;
                return;
            }

            context.Result = RequestFilteringResult.Continue;
        }
    }
}

using System.IO;
using System.Linq;

namespace RequestFiltering.FileExtensions
{
    public class FileExtensionRequestFilter : RequestFilter<FileExtensionsOptions>
    {
        public FileExtensionRequestFilter() : this(new FileExtensionsOptions())
        {

        }

        public FileExtensionRequestFilter(FileExtensionsOptions options)
        {
            Options = options;
        }

        public override FileExtensionsOptions Options { get; }

        public override void ApplyFilter(RequestFilteringContext context)
        {
            var extension = Path.GetExtension(context.HttpContext.Request.Path.Value);

            if (Options.AllowUnlisted)
            {
                if (Options.FileExtensionsCollection.Any(f => f.FileExtension == extension && f.Allowed == false))
                {
                    context.HttpContext.Response.StatusCode = 404;
                    context.Result = RequestFilteringResult.StopFilters;
                    return;
                }

                context.Result = RequestFilteringResult.Continue;
            }
            else
            {
                if (Options.FileExtensionsCollection.Any(f => f.FileExtension == extension && f.Allowed == true))
                {
                    context.Result = RequestFilteringResult.Continue;
                    return;
                }

                context.HttpContext.Response.StatusCode = 404;
                context.Result = RequestFilteringResult.StopFilters;
            }
        }
    }
}

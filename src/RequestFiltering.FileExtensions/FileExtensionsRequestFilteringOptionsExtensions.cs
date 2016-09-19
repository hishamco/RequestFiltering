using System;

namespace RequestFiltering.FileExtensions
{
    public static class FileExtensionsRequestFilteringOptionsExtensions
    {
        public static RequestFilteringOptions AddFileExtensionRequestFilter(this RequestFilteringOptions requestFilteringOptions, FileExtensionsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var filter = new FileExtensionRequestFilter(options);

            requestFilteringOptions.Filters.Add(filter);
            return requestFilteringOptions;
        }
    }
}

using System.Collections.Generic;

namespace RequestFiltering.FileExtensions
{
    public class FileExtensionsOptions : IRequestFilterOptions
    {
        public bool AllowUnlisted { get; set; } = true;

        public IList<FileExtensionsElement> FileExtensionsCollection { get; set; } = new List<FileExtensionsElement>();
    }
}

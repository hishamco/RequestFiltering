using Microsoft.AspNetCore.Http;

namespace RequestFiltering
{
    public class RequestFilteringContext
    {
        public HttpContext HttpContext { get; set; }

        public RequestFilteringResult Result { get; set; }
    }
}

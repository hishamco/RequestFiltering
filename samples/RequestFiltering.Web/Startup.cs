using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RequestFiltering.FileExtensions;
using RequestFiltering.Headers;
using RequestFiltering.HiddenSegments;
using RequestFiltering.HttpVerbs;
using RequestFiltering.IPAddress;
using RequestFiltering.QueryStrings;
using RequestFiltering.SqlInjection;
using RequestFiltering.Urls;
using System.Collections.Generic;

namespace RequestFiltering.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var options = new RequestFilteringOptions()
                .AddFileExtensionRequestFilter(new FileExtensionsOptions
                {
                    FileExtensionsCollection = new List<FileExtensionsElement>
                    {
                        new FileExtensionsElement() { FileExtension = ".jpg", Allowed = true },
                        new FileExtensionsElement() { FileExtension = ".psd", Allowed = false }
                    }
                })
                .AddHttpVerbRequestFilter(new HttpVerbsOptions
                {
                    AllowUnlisted = false,
                    HttpVerbsCollection = new List<HttpVerbElement>
                    {
                        new HttpVerbElement() { Verb = HttpVerb.Get, Allowed = true }
                    }
                })
                .AddQueryStringRequestFilter(new QueryStringsOptions
                {
                    AllowUnlisted = false,
                    QueryStringsCollection = new List<QueryStringElement>
                    {
                        new QueryStringElement() { QueryString = "id", Allowed = true },
                        new QueryStringElement() { QueryString = "name", Allowed = false }
                    }
                })
                .AddHiddenSegmentRequestFilter(new HiddenSegmentsOptions
                {
                    HiddenSegmentsCollection = new List<HiddenSegmentElement>
                    {
                        new HiddenSegmentElement() { Segment = "Private" }
                    }
                })
                .AddHeaderRequestFilter(new HeadersOptions
                {
                    HeadersCollection = new List<HeaderElement>
                    {
                        new HeaderElement() { Header = "X-Auth", SizeLimit = 5 }
                    }
                })
                .AddUrlRequestFilter(new UrlsOptions
                {
                    DeniedUrlSequences = new[] { "me" },
                    AllowedUrls = new[] { "/Home" }
                });

                // Uncomment the following line to filter using IP address
                /*.AddIPAddressRequestFilter(new IPAddressOptions
                {
                    IPAddresses = new[] { "::1" }
                })*/

                // Uncomment following line to filter the SQL injection
                //.AddSqlInjectionRequestFilter();

            app.UseRequestFiltering(options);

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}

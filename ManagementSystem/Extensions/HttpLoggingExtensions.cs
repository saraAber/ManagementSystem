using log4net.Config;
using log4net;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ManagementSystem.Extensions
{
    public static class HttpLoggingExtensions
    {
        public static void AddHttpLogging(this IServiceCollection services)
        {
            services.AddHttpLogging(options =>
            {
                // Set the logging fields to capture both request and response
                options.LoggingFields = HttpLoggingFields.Request | HttpLoggingFields.Response | HttpLoggingFields.ResponseStatusCode;

                // Set the request body log size limit
                options.RequestBodyLogLimit = 4096;

                // Set the response body log size limit
                options.ResponseBodyLogLimit = 4096;
            });
        }
    }
}

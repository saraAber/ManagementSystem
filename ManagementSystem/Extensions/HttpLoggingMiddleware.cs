
using BLL.Interface;
using DTO;
using log4net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;  // The next middleware in the pipeline
    private readonly ILog _logger;          // Logger used for logging request details

    // Constructor that accepts the next middleware delegate and a logger instance
    public RequestLoggingMiddleware(RequestDelegate next, ILog log)
    {
        _next = next;   // Set the next middleware in the pipeline
        _logger = log;  // Set the logger instance
    }

    // This method is called for every HTTP request, and handles the logging logic
    public async Task Invoke(HttpContext context)
    {
        try
        {
            // Proceed with the next middleware in the pipeline
            await _next(context);
        }
        finally
        {
            var body = "";

            // Enable request buffering so we can read the request body multiple times
            context.Request.EnableBuffering();

            // Check if the request contains any body content
            if (context.Request.ContentLength > 0)
            {
                // Read the request body into a string (the request stream is read once, then reset)
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    body = await reader.ReadToEndAsync();  // Read the body content asynchronously
                    context.Request.Body.Position = 0;    // Reset the position of the request body stream for other middlewares
                }
            }

            // Log the relevant request and response information
            _logger.Info(new
            {
                Route = context.Request.Path,          // The request's route or path
                StatusCode = context.Response?.StatusCode,  // The response status code (optional, in case no response is set yet)
                Method = context.Request?.Method,      // The HTTP method (GET, POST, etc.)
                Body = body,                           // The body of the request (if present)
                User = context.User?.Claims                 // The claims associated with the current authenticated user (if any).
            });
        }
    }
}






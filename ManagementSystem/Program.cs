using BLL;
using ManagementSystem.Extensions;

// Create the WebApplication builder (ASP.NET Core 6+ style)
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS (Cross-Origin Resource Sharing) configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        // Allow all origins (this is a very permissive CORS policy, adjust as needed for security)
        policy.WithOrigins("*")
              .WithHeaders("*")
              .WithMethods("*");
    });
});

// Add authentication services (using JWT, as configured in AddAuthentication extension method)
builder.Services.AddAuthentication(builder.Configuration);

// Add authorization services
builder.Services.AddAuthorization();

// Add controllers to handle incoming HTTP requests
builder.Services.AddControllers();

// Add endpoint API explorer to allow for OpenAPI/Swagger generation
builder.Services.AddEndpointsApiExplorer();

// Add custom services (e.g., DI for your application's services) from a method in your service container class
builder.Services.AddServices(builder.Configuration);

// Register IAuthService with dependency injection (DI) container
builder.Services.AddScoped<IAuthService, AuthService>();

// Enable HTTP request logging (for debugging and monitoring)
builder.Services.AddHttpLogging();

// Add log4net for logging
builder.Services.AddLog4net();

// Add Swagger generation for API documentation and UI
builder.Services.AddSwaggerGen();

// Build the WebApplication from the configuration
var app = builder.Build();

// Enable HTTP logging middleware to log request/response details
app.UseHttpLogging();

// Configure the HTTP request pipeline.

// If the application is in development mode, enable Swagger UI for testing and documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use custom middleware for logging the requests (e.g., logging route, method, body, etc.)
app.UseMiddleware<RequestLoggingMiddleware>();

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable CORS middleware, which will handle cross-origin requests according to the policy defined above
app.UseCors();

// Enable authentication middleware to handle JWT token validation and user authentication
app.UseAuthentication();

// Enable authorization middleware to ensure that only authorized users can access protected resources
app.UseAuthorization();

// Map controllers to the request pipeline, so incoming requests to API endpoints are handled by controllers
app.MapControllers();

// Run the application
app.Run();

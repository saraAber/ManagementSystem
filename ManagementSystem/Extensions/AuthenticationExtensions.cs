using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ManagementSystem.Extensions
{
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Extension method to add JWT authentication to the application's service collection.
        /// This method configures the authentication scheme and sets up JWT bearer token validation parameters.
        /// </summary>
        /// <param name="services">The service collection to add the authentication services to.</param>
        /// <param name="configuration">The configuration object to retrieve the JWT settings from.</param>

        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // Add authentication services to the container

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Configure JWT bearer token authentication

            .AddJwtBearer(options =>
            {
                // Set the token validation parameters

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? ""))
                };
            });
        }


    }
}

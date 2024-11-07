using DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementSystem.Extensions
{
    public interface IAuthService
    {
        string GenerateJwtToken(ManagerDTO userInfo);
    }
    /// <summary>
    /// Implementation of IAuthService that provides the functionality for generating JWT tokens.
    /// </summary>
    public class AuthService : IAuthService
    {
        // Configuration object to access app settings (like the JWT secret key and issuer)
        private readonly IConfiguration _config;

        /// <summary>
        /// Constructor that injects the IConfiguration instance to access configuration settings.
        /// </summary>
        /// <param name="config">The configuration object that contains app settings.</param>
        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Generates a JWT token based on the provided user information.
        /// </summary>
        /// <param name="userInfo">The user information (DTO) to be included in the token.</param>
        /// <returns>The generated JWT token as a string.</returns>
        public string GenerateJwtToken(ManagerDTO userInfo)
        {
            // Create the security key using the key from the configuration (appsettings)
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //  Create the signing credentials using the security key and HMACSHA256 algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //  Define the claims to include in the token (e.g., user info such as Id, Email, FullName)
            List<Claim> claims = new()
        {
            new Claim("id", userInfo.Id.ToString()),  
            new Claim("Name", userInfo.Name),      
             new Claim("Email", userInfo.Email),  
            new Claim("FullName", userInfo.FullName)  
        };

            //  Create the JWT security token with issuer, audience, claims, expiration, and signing credentials
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],      
                _config["Jwt:Issuer"],      
                claims,                     // The claims (user-specific data) included in the token
                expires: DateTime.Now.AddMinutes(120),  // Token expiration time (2 hours)
                signingCredentials: credentials  // Signing credentials (security key and algorithm)
            );

            //  Return the generated JWT token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
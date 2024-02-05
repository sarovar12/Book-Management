using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace BookManagement.Application.Utils
{
    public class JwtTokenServices
    {
        public static string GetUsernameFromToken(HttpContext httpContext)
        {
            // Get the Authorization header from the HTTP context
            var authorizationHeader = httpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                throw new Exception("Authorization header not found");
            }

            // Extract the token from the Authorization header
            string token = authorizationHeader.ToString().Replace("Bearer ", "");

            // Decode the token
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            // Extract and return the username
            return jsonToken?.Claims.First(claim => claim.Type == "Username").Value;
        }
    }
}

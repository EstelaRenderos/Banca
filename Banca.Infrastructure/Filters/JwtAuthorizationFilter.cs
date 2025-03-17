using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Banca.Infrastructure.Filters
{
    public class JwtAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public JwtAuthorizationFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;

            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
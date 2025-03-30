using Microsoft.IdentityModel.Tokens;
using svc.system.center.domain.Config;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace svc.system.center.api.Helpers
{
    public static class TokenHelpers
    {
        #region Generate Access Token

        public static string GetAccessToken(AuthConfig AuthConfig, string profile)
        {
            Claim[] claims = new[] {
                new Claim(ClaimTypes.UserData, profile),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthConfig.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(AuthConfig.Issuer, AuthConfig.Audiance, expires: DateTime.Now.AddMinutes(AuthConfig.AccessExpireMinutes), signingCredentials: creds, claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion Generate Access Token
    }
}

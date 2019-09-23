using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilms.JwtClass
{
    public class Jwt
    {
        public Dictionary<string, string> DecodeJwt(IHttpContextAccessor _httpContextAccessor) {
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadJwtToken(accessToken) as JwtSecurityToken;
            var idUser = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId).Value;
            var email = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value;
            Dictionary<string, string> data = new Dictionary<string, string>{
            {"idUser", idUser},
            {"Email", email},
            };
            return data;
        }
    }
}

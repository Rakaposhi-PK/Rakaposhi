using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rakaposhi.API.Core.JWTauthentication
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        public Token? Authenticate(string user)
        {
			if(user == null || user != "Maaz")
            {
				return null;
            }

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes("This is the private key");
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user)
				}),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new Token { TokenManager = tokenHandler.WriteToken(token) };
		}
    }
}

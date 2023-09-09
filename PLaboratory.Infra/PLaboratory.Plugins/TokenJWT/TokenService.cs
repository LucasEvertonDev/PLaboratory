using Microsoft.IdentityModel.Tokens;
using PLaboratory.Core.Domain.Contansts.JWT;
using PLaboratory.Core.Domain.DbContexts.Entities;
using PLaboratory.Core.Domain.Infra.Claims;
using PLaboratory.Core.Domain.Plugins.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PLaboratory.Plugins.TokenJWT;

public class TokenService : ITokenService
{
    public Task<(string, DateTime)> GenerateToken(User user, string clientId, List<Role> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(JWTContants.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(JWTUserClaims.Name, user.Name),
                new Claim(JWTUserClaims.Email, user.Email),
                new Claim(JWTUserClaims.UserId, user.Id.ToString()),
                new Claim(JWTUserClaims.ClientId, clientId),
            }),
            Expires = DateTime.UtcNow.AddMinutes(JWTContants.ExpireInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        foreach (var role in roles)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role?.Name));
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Task.FromResult((tokenHandler.WriteToken(token), DateTime.Now.AddMinutes(JWTContants.ExpireInMinutes)));
    }
}

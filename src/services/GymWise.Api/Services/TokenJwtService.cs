using GymWise.Api.Configuration;
using GymWise.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymWise.Api.Services
{
    public class TokenJwtService : ITokenService
    {
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly UserManager<User> _userManager;

        public TokenJwtService(
            IOptions<TokenConfiguration> tokenConfiguration,
            UserManager<User> userManager
        )
        {
            _tokenConfiguration = tokenConfiguration.Value;
            _userManager = userManager;
        }

        public async Task<string> GenerateTokenJwtAsync(User user)
        {
            var identityClaims = new ClaimsIdentity();

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
                identityClaims.AddClaim(new Claim(ClaimTypes.Role, role));

            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, user.Email!));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            identityClaims.AddClaims(await _userManager.GetClaimsAsync(user));

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_tokenConfiguration.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_tokenConfiguration.ExpiresHours),
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.ValidIn,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

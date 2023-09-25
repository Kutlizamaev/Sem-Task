using CarFleet.BLL.Responces;
using CarFleet.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarFleet.BLL.Services
{
    public class JwtService
    {
        private const int EXPIRATION_MINUTES = 5;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public JwtService(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<AuthResponse> Createtoken(User user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);

            var token = CreateJwtToken(
                await CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHander = new JwtSecurityTokenHandler();

            return new AuthResponse
            {
                Token = tokenHander.WriteToken(token),
                Expiration = expiration
            };
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
            new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private async Task<Claim[]> CreateClaims(User user) =>
            new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.UserName),
                new Claim("roles",  (await _userManager.GetRolesAsync(user)).FirstOrDefault()),
                new Claim("email", user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            };

        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                    ),
                SecurityAlgorithms.HmacSha256
                );
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartClinic.Configurations;
using SmartClinic.Models;

namespace SmartClinic.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _options;

    public JwtTokenGenerator(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public (string Token, DateTime ExpiresAt) GenerateToken(UserAccount account)
    {
        var expiration = DateTime.UtcNow.AddMinutes(_options.ExpiryMinutes);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, account.Username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, account.Role)
        };

        if (account.DoctorId.HasValue)
        {
            claims.Add(new("doctorId", account.DoctorId.Value.ToString()));
        }

        if (account.PatientId.HasValue)
        {
            claims.Add(new("patientId", account.PatientId.Value.ToString()));
        }

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return (new JwtSecurityTokenHandler().WriteToken(token), expiration);
    }
}

using SmartClinic.Models;

namespace SmartClinic.Services;

public interface IJwtTokenGenerator
{
    (string Token, DateTime ExpiresAt) GenerateToken(UserAccount account);
}

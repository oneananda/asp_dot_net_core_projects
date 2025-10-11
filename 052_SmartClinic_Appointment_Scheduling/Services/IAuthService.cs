using SmartClinic.DTOs;

namespace SmartClinic.Services;

public interface IAuthService
{
    ServiceResult<AuthResponse> Authenticate(LoginRequest request);
}

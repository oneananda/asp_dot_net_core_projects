using SmartClinic.DTOs;
using SmartClinic.Repositories;

namespace SmartClinic.Services;

public class AuthService : IAuthService
{
    private readonly IClinicRepository _repository;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthService(IClinicRepository repository, IJwtTokenGenerator tokenGenerator)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
    }

    public ServiceResult<AuthResponse> Authenticate(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
        {
            return ServiceResult<AuthResponse>.Fail("Username and password are required.");
        }

        var account = _repository.GetUser(request.Username.Trim());
        if (account is null || account.Password != request.Password)
        {
            return ServiceResult<AuthResponse>.Fail("Invalid username or password.");
        }

        var (token, expiresAt) = _tokenGenerator.GenerateToken(account);
        var response = new AuthResponse(
            token,
            expiresAt,
            account.Role,
            account.DoctorId?.ToString(),
            account.PatientId?.ToString());

        return ServiceResult<AuthResponse>.Ok(response);
    }
}

namespace SmartClinic.DTOs;

public record LoginRequest(string Username, string Password);

public record AuthResponse(string AccessToken, DateTime ExpiresAt, string Role, string? DoctorId, string? PatientId);

namespace SmartClinic.DTOs;

public record CreatePatientRequest(string Name, DateOnly DateOfBirth, string? Email, string? PhoneNumber, string? InsuranceProvider);

public record UpdatePatientRequest(string Name, DateOnly DateOfBirth, string? Email, string? PhoneNumber, string? InsuranceProvider);

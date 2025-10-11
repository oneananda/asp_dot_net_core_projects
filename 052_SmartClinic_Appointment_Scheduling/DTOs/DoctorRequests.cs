namespace SmartClinic.DTOs;

public record CreateDoctorRequest(string Name, string Specialization, string Email, string PhoneNumber, ICollection<string>? AvailableDays);

public record UpdateDoctorRequest(string Name, string Specialization, string Email, string PhoneNumber, ICollection<string>? AvailableDays);

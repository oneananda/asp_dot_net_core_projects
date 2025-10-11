namespace SmartClinic.Models;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string InsuranceProvider { get; set; } = string.Empty;
}

namespace SmartClinic.Models;

public class UserAccount
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public Guid? DoctorId { get; set; }
    public Guid? PatientId { get; set; }
}

namespace SmartClinic.Models;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Reason { get; set; } = string.Empty;
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
}

public enum AppointmentStatus
{
    Scheduled,
    Confirmed,
    Completed,
    Cancelled
}

using SmartClinic.Models;

namespace SmartClinic.DTOs;

public record ScheduleAppointmentRequest(Guid DoctorId, Guid PatientId, DateTime ScheduledAt, string? Reason);

public record UpdateAppointmentStatusRequest(AppointmentStatus Status);

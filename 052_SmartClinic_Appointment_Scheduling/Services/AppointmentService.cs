using SmartClinic.DTOs;
using SmartClinic.Models;
using SmartClinic.Repositories;

namespace SmartClinic.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IClinicRepository _repository;

    public AppointmentService(IClinicRepository repository)
    {
        _repository = repository;
    }

    public ServiceResult<Appointment> Cancel(Guid id, string? reason = null)
    {
        var appointment = _repository.GetAppointment(id);
        if (appointment is null)
        {
            return ServiceResult<Appointment>.Fail("Appointment not found.");
        }

        appointment.Status = AppointmentStatus.Cancelled;
        var trimmedReason = reason?.Trim();
        if (!string.IsNullOrWhiteSpace(trimmedReason) && !appointment.Reason.Contains(trimmedReason, StringComparison.OrdinalIgnoreCase))
        {
            appointment.Reason = string.Concat(appointment.Reason, " | Cancelled: ", trimmedReason);
        }

        return _repository.UpdateAppointment(appointment)
            ? ServiceResult<Appointment>.Ok(appointment)
            : ServiceResult<Appointment>.Fail("Unable to cancel appointment.");
    }

    public IEnumerable<Appointment> GetAll() => _repository.GetAppointments();

    public Appointment? GetById(Guid id) => _repository.GetAppointment(id);

    public IEnumerable<Appointment> GetForDoctor(Guid doctorId) => _repository.GetAppointmentsForDoctor(doctorId);

    public IEnumerable<Appointment> GetForPatient(Guid patientId) => _repository.GetAppointmentsForPatient(patientId);

    public ServiceResult<Appointment> Schedule(ScheduleAppointmentRequest request)
    {
        var doctor = _repository.GetDoctor(request.DoctorId);
        if (doctor is null)
        {
            return ServiceResult<Appointment>.Fail("Doctor not found.");
        }

        var patient = _repository.GetPatient(request.PatientId);
        if (patient is null)
        {
            return ServiceResult<Appointment>.Fail("Patient not found.");
        }

        if (request.ScheduledAt <= DateTime.UtcNow)
        {
            return ServiceResult<Appointment>.Fail("Appointments must be scheduled in the future.");
        }

        var doctorAppointments = _repository.GetAppointmentsForDoctor(request.DoctorId);
        if (doctorAppointments.Any(a => Math.Abs((a.ScheduledAt - request.ScheduledAt).TotalMinutes) < 30 && a.Status != AppointmentStatus.Cancelled))
        {
            return ServiceResult<Appointment>.Fail("Doctor already has an appointment in this time slot.");
        }

        var patientAppointments = _repository.GetAppointmentsForPatient(request.PatientId);
        if (patientAppointments.Any(a => Math.Abs((a.ScheduledAt - request.ScheduledAt).TotalMinutes) < 30 && a.Status != AppointmentStatus.Cancelled))
        {
            return ServiceResult<Appointment>.Fail("Patient already has an appointment in this time slot.");
        }

        var appointment = new Appointment
        {
            DoctorId = request.DoctorId,
            PatientId = request.PatientId,
            ScheduledAt = DateTime.SpecifyKind(request.ScheduledAt, DateTimeKind.Utc),
            Reason = (request.Reason ?? string.Empty).Trim(),
            Status = AppointmentStatus.Scheduled
        };

        return ServiceResult<Appointment>.Ok(_repository.AddAppointment(appointment));
    }

    public ServiceResult<Appointment> UpdateStatus(Guid id, UpdateAppointmentStatusRequest request)
    {
        var appointment = _repository.GetAppointment(id);
        if (appointment is null)
        {
            return ServiceResult<Appointment>.Fail("Appointment not found.");
        }

        appointment.Status = request.Status;
        return _repository.UpdateAppointment(appointment)
            ? ServiceResult<Appointment>.Ok(appointment)
            : ServiceResult<Appointment>.Fail("Unable to update appointment.");
    }
}

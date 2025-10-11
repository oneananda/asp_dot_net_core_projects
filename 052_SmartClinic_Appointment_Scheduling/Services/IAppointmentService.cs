using SmartClinic.DTOs;
using SmartClinic.Models;

namespace SmartClinic.Services;

public interface IAppointmentService
{
    IEnumerable<Appointment> GetAll();
    IEnumerable<Appointment> GetForDoctor(Guid doctorId);
    IEnumerable<Appointment> GetForPatient(Guid patientId);
    Appointment? GetById(Guid id);
    ServiceResult<Appointment> Schedule(ScheduleAppointmentRequest request);
    ServiceResult<Appointment> UpdateStatus(Guid id, UpdateAppointmentStatusRequest request);
    ServiceResult<Appointment> Cancel(Guid id, string? reason = null);
}

using SmartClinic.Models;

namespace SmartClinic.Repositories;

public interface IClinicRepository
{
    IEnumerable<Doctor> GetDoctors();
    Doctor? GetDoctor(Guid id);
    Doctor AddDoctor(Doctor doctor);
    bool UpdateDoctor(Doctor doctor);
    bool RemoveDoctor(Guid id);

    IEnumerable<Patient> GetPatients();
    Patient? GetPatient(Guid id);
    Patient AddPatient(Patient patient);
    bool UpdatePatient(Patient patient);
    bool RemovePatient(Guid id);

    IEnumerable<Appointment> GetAppointments();
    IEnumerable<Appointment> GetAppointmentsForDoctor(Guid doctorId);
    IEnumerable<Appointment> GetAppointmentsForPatient(Guid patientId);
    Appointment? GetAppointment(Guid id);
    Appointment AddAppointment(Appointment appointment);
    bool UpdateAppointment(Appointment appointment);

    UserAccount? GetUser(string username);
    void UpsertUser(UserAccount account);
}

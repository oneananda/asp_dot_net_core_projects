using System.Collections.Concurrent;
using SmartClinic.Models;

namespace SmartClinic.Repositories;

public class InMemoryClinicRepository : IClinicRepository
{
    private readonly ConcurrentDictionary<Guid, Doctor> _doctors = new();
    private readonly ConcurrentDictionary<Guid, Patient> _patients = new();
    private readonly ConcurrentDictionary<Guid, Appointment> _appointments = new();
    private readonly ConcurrentDictionary<string, UserAccount> _users = new(StringComparer.OrdinalIgnoreCase);

    public InMemoryClinicRepository()
    {
        Seed();
    }

    public Doctor AddDoctor(Doctor doctor)
    {
        doctor.Id = doctor.Id == Guid.Empty ? Guid.NewGuid() : doctor.Id;
        _doctors[doctor.Id] = doctor;
        return doctor;
    }

    public Patient AddPatient(Patient patient)
    {
        patient.Id = patient.Id == Guid.Empty ? Guid.NewGuid() : patient.Id;
        _patients[patient.Id] = patient;
        return patient;
    }

    public Appointment AddAppointment(Appointment appointment)
    {
        appointment.Id = appointment.Id == Guid.Empty ? Guid.NewGuid() : appointment.Id;
        _appointments[appointment.Id] = appointment;
        return appointment;
    }

    public IEnumerable<Appointment> GetAppointments() => _appointments.Values.OrderBy(a => a.ScheduledAt);

    public IEnumerable<Appointment> GetAppointmentsForDoctor(Guid doctorId) =>
        _appointments.Values.Where(a => a.DoctorId == doctorId).OrderBy(a => a.ScheduledAt);

    public IEnumerable<Appointment> GetAppointmentsForPatient(Guid patientId) =>
        _appointments.Values.Where(a => a.PatientId == patientId).OrderBy(a => a.ScheduledAt);

    public Appointment? GetAppointment(Guid id) =>
        _appointments.TryGetValue(id, out var appointment) ? appointment : null;

    public Doctor? GetDoctor(Guid id) =>
        _doctors.TryGetValue(id, out var doctor) ? doctor : null;

    public IEnumerable<Doctor> GetDoctors() => _doctors.Values.OrderBy(d => d.Name);

    public Patient? GetPatient(Guid id) =>
        _patients.TryGetValue(id, out var patient) ? patient : null;

    public IEnumerable<Patient> GetPatients() => _patients.Values.OrderBy(p => p.Name);

    public bool RemoveDoctor(Guid id)
    {
        var removed = _doctors.TryRemove(id, out _);
        if (removed)
        {
            foreach (var user in _users.Values.Where(u => u.DoctorId == id).ToList())
            {
                _users.TryRemove(user.Username, out _);
            }
        }
        return removed;
    }

    public bool RemovePatient(Guid id)
    {
        var removed = _patients.TryRemove(id, out _);
        if (removed)
        {
            foreach (var user in _users.Values.Where(u => u.PatientId == id).ToList())
            {
                _users.TryRemove(user.Username, out _);
            }
        }
        return removed;
    }

    public bool UpdateDoctor(Doctor doctor)
    {
        if (!_doctors.ContainsKey(doctor.Id))
        {
            return false;
        }

        _doctors[doctor.Id] = doctor;
        return true;
    }

    public bool UpdatePatient(Patient patient)
    {
        if (!_patients.ContainsKey(patient.Id))
        {
            return false;
        }

        _patients[patient.Id] = patient;
        return true;
    }

    public bool UpdateAppointment(Appointment appointment)
    {
        if (!_appointments.ContainsKey(appointment.Id))
        {
            return false;
        }

        _appointments[appointment.Id] = appointment;
        return true;
    }

    public UserAccount? GetUser(string username) =>
        _users.TryGetValue(username, out var account) ? account : null;

    public void UpsertUser(UserAccount account)
    {
        account.Id = account.Id == Guid.Empty ? Guid.NewGuid() : account.Id;
        _users[account.Username] = account;
    }

    private void Seed()
    {
        var doctor = new Doctor
        {
            Name = "Dr. Amelia Carson",
            Specialization = "Cardiology",
            Email = "amelia.carson@smartclinic.test",
            PhoneNumber = "+1-555-0100",
            AvailableDays = new List<string> { "Monday", "Wednesday", "Friday" }
        };
        AddDoctor(doctor);

        var patient = new Patient
        {
            Name = "Marcus Lee",
            DateOfBirth = new DateOnly(1990, 4, 12),
            Email = "marcus.lee@smartclinic.test",
            PhoneNumber = "+1-555-0142",
            InsuranceProvider = "Global Health"
        };
        AddPatient(patient);

        UpsertUser(new UserAccount
        {
            Username = "dr.carson",
            Password = "Doctor@123",
            Role = "Doctor",
            DoctorId = doctor.Id
        });

        UpsertUser(new UserAccount
        {
            Username = "marcus.lee",
            Password = "Patient@123",
            Role = "Patient",
            PatientId = patient.Id
        });

        UpsertUser(new UserAccount
        {
            Username = "admin",
            Password = "Admin@123",
            Role = "Administrator"
        });
    }
}

using SmartClinic.DTOs;
using SmartClinic.Models;
using SmartClinic.Repositories;

namespace SmartClinic.Services;

public class PatientService : IPatientService
{
    private readonly IClinicRepository _repository;

    public PatientService(IClinicRepository repository)
    {
        _repository = repository;
    }

    public ServiceResult<Patient> Create(CreatePatientRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return ServiceResult<Patient>.Fail("Patient name is required.");
        }

        var patient = new Patient
        {
            Name = request.Name.Trim(),
            DateOfBirth = request.DateOfBirth,
            Email = (request.Email ?? string.Empty).Trim(),
            PhoneNumber = (request.PhoneNumber ?? string.Empty).Trim(),
            InsuranceProvider = (request.InsuranceProvider ?? string.Empty).Trim()
        };

        return ServiceResult<Patient>.Ok(_repository.AddPatient(patient));
    }

    public bool Delete(Guid id) => _repository.RemovePatient(id);

    public IEnumerable<Patient> GetAll() => _repository.GetPatients();

    public Patient? GetById(Guid id) => _repository.GetPatient(id);

    public ServiceResult<Patient> Update(Guid id, UpdatePatientRequest request)
    {
        var existing = _repository.GetPatient(id);
        if (existing is null)
        {
            return ServiceResult<Patient>.Fail("Patient not found.");
        }

        existing.Name = request.Name.Trim();
        existing.DateOfBirth = request.DateOfBirth;
        existing.Email = (request.Email ?? string.Empty).Trim();
        existing.PhoneNumber = (request.PhoneNumber ?? string.Empty).Trim();
        existing.InsuranceProvider = (request.InsuranceProvider ?? string.Empty).Trim();

        return _repository.UpdatePatient(existing)
            ? ServiceResult<Patient>.Ok(existing)
            : ServiceResult<Patient>.Fail("Unable to update patient.");
    }
}

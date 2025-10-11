using SmartClinic.DTOs;
using SmartClinic.Models;
using SmartClinic.Repositories;

namespace SmartClinic.Services;

public class DoctorService : IDoctorService
{
    private readonly IClinicRepository _repository;

    public DoctorService(IClinicRepository repository)
    {
        _repository = repository;
    }

    public ServiceResult<Doctor> Create(CreateDoctorRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return ServiceResult<Doctor>.Fail("Doctor name is required.");
        }

        var doctor = new Doctor
        {
            Name = request.Name.Trim(),
            Specialization = request.Specialization.Trim(),
            Email = request.Email.Trim(),
            PhoneNumber = request.PhoneNumber.Trim(),
            AvailableDays = (request.AvailableDays ?? Array.Empty<string>()).Select(day => day.Trim()).Where(day => !string.IsNullOrWhiteSpace(day)).ToList()
        };

        return ServiceResult<Doctor>.Ok(_repository.AddDoctor(doctor));
    }

    public bool Delete(Guid id) => _repository.RemoveDoctor(id);

    public IEnumerable<Doctor> GetAll() => _repository.GetDoctors();

    public Doctor? GetById(Guid id) => _repository.GetDoctor(id);

    public ServiceResult<Doctor> Update(Guid id, UpdateDoctorRequest request)
    {
        var existing = _repository.GetDoctor(id);
        if (existing is null)
        {
            return ServiceResult<Doctor>.Fail("Doctor not found.");
        }

        existing.Name = request.Name.Trim();
        existing.Specialization = request.Specialization.Trim();
        existing.Email = request.Email.Trim();
        existing.PhoneNumber = request.PhoneNumber.Trim();
        existing.AvailableDays = (request.AvailableDays ?? Array.Empty<string>()).Select(day => day.Trim()).Where(day => !string.IsNullOrWhiteSpace(day)).ToList();

        return _repository.UpdateDoctor(existing)
            ? ServiceResult<Doctor>.Ok(existing)
            : ServiceResult<Doctor>.Fail("Unable to update doctor.");
    }
}

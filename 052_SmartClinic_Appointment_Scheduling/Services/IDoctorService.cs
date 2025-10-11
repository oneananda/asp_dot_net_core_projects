using SmartClinic.DTOs;
using SmartClinic.Models;

namespace SmartClinic.Services;

public interface IDoctorService
{
    IEnumerable<Doctor> GetAll();
    Doctor? GetById(Guid id);
    ServiceResult<Doctor> Create(CreateDoctorRequest request);
    ServiceResult<Doctor> Update(Guid id, UpdateDoctorRequest request);
    bool Delete(Guid id);
}

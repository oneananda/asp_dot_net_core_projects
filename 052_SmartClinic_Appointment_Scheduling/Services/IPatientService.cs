using SmartClinic.DTOs;
using SmartClinic.Models;

namespace SmartClinic.Services;

public interface IPatientService
{
    IEnumerable<Patient> GetAll();
    Patient? GetById(Guid id);
    ServiceResult<Patient> Create(CreatePatientRequest request);
    ServiceResult<Patient> Update(Guid id, UpdatePatientRequest request);
    bool Delete(Guid id);
}

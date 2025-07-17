using System.Collections.Generic;
using NancyFx_Application.Models;

namespace NancyFx_Application.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee Add(Employee emp);
    }
}

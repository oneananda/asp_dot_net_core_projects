using NancyFx_Application.Models;
using System.Collections.Generic;

namespace NancyFx_Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public List<Employee> GetAll() => _employees;

        public Employee Add(Employee emp)
        {
            _employees.Add(emp);
            return emp;
        }
    }
}

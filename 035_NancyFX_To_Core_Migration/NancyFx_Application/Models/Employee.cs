using System;

namespace NancyFx_Application.Models
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}

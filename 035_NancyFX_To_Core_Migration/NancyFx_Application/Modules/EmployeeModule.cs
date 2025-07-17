using Nancy;
using Nancy.ModelBinding;
using NancyFx_Application.Models;
using NancyFx_Application.Services;


namespace NancyFx_Application.Modules
{

    public class EmployeeModule : NancyModule
    {
        public EmployeeModule(IEmployeeService service)
            : base("/nancy/employee")
        {
            Get("/", _ => Response.AsJson(service.GetAll()));

            Post("/", args =>
            {
                var emp = this.Bind<Employee>();
                return Response.AsJson(service.Add(emp));
            });
        }
    }

}

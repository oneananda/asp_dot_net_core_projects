using Nancy;
using Nancy.TinyIoc;
using NancyFx_Application.Services;

namespace NancyFx_Application
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IEmployeeService, EmployeeService>().AsSingleton();
        }
    }
}

namespace NancyFx_Application
{
    using Nancy;
    using Nancy.TinyIoc;
    using NancyFx_Application.Services;

    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IEmployeeService, EmployeeService>().AsSingleton();
        }
    }

}

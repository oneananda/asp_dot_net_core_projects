using Nancy;

namespace _035_NancyFX_To_Core_Migration
{
    public class NancyFx_Class : NancyModule
    {
        public NancyFx_Class()
        {
            Get("/", args => "Hello from NancyFX!");

            Get("/greet/{name}", args => $"Hello, {args.name}!");
        }
    }
}

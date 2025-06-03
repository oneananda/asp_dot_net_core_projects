using System.Threading.Tasks;
using Grpc.Core;
using GrpcServiceTemplate;

namespace GrpcServiceTemplate.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var reply = new HelloReply
            {
                Message = $"Hello, {request.Name}! Welcome to gRPC."
            };
            return Task.FromResult(reply);
        }
    }
}

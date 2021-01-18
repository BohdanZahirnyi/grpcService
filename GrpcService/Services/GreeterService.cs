using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Interfaces;
using GrpcService.Models;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private IRepo<User> _repo;

        public GreeterService(ILogger<GreeterService> logger, IRepo<User> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<ReturnUserById> GetById(GetUserById request, ServerCallContext context)
        {
            var name = _repo.Get(request.Id).Name;
            return Task.FromResult(new ReturnUserById
            {
                Message = $"Hello, {name}!"
            });
        }
    }
}
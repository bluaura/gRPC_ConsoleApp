using Greet;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using static Greet.Greeter;

namespace gRPCConsoleServer;

public class GreeterServer : Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        var reply = new HelloReply
        {
            Message = "[ServerMessage] Hello " + request.Name
        };
        return Task.FromResult(reply);
    }
}

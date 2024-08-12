using Command;
using Grpc.Core;
using System;
using System.Threading.Tasks;
using static Command.CommandBase;

namespace gRPCConsoleClient2;

public class CommandServer : Command.CommandBase
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

using Grpc.Core;
using Command;

using GrpcConsolClient2;

const int servPort = 50051;

/*
Server server = new Server
{
    Services = { Greeter.BindService(new GreeterServer()) },
    Ports = { new ServerPort("localhost", servPort, ServerCredentials.Insecure) }
};

server.Start();

Console.WriteLine("Greeter server listening on port " + servPort);
*/

Channel channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
var client = new Command.CommandClient(channel);
String user = "daehwan";

var reply = client.SayHello(new HelloRequest { Name = user });
Console.WriteLine("Greeting: " + reply.Message);

channel.ShutdownAsync().Wait();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

//server.ShutdownAsync().Wait();

using Grpc.Core;
using Greet;

Channel channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
var client = new Greeter.GreeterClient(channel);
String user = "daehwan";

var reply = client.SayHello(new HelloRequest { Name = user });
Console.WriteLine("Greeting: " + reply.Message);

foreach (string str in reply.Message)
{
    Console.WriteLine(str);
}

channel.ShutdownAsync().Wait();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

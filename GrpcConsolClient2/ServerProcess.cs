using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grpc.Core;
using Greet;

namespace GrpcConsolClient2
{
    class ServerProcess
    {
        public static void ServerStart()
        {
            /*
            const int Port = 50052;

            ServerProcess server = new ServerProcess
            {
                Services = { Greeter.BindService(new GreeterServer()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
            */
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Demo;
using Grpc.Core;
using DemoServer.utils;


namespace DemoServer
{
    class Program
    {
        const int PORT = 55001;
        static void Main(string[] args)
        {
            string hostname = Dns.GetHostName();
            IPAddress[] iplist = Dns.GetHostAddresses(hostname);
            foreach (IPAddress ipa in iplist)
            {
                if (ipa.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    Console.WriteLine(ipa.ToString());
            }

            string hostName;
            if (IPAddressUtil.GetLocalIP() != null)
            {
                hostName = IPAddressUtil.GetLocalIP();
                Console.WriteLine("Get Local IP :" + hostName);
            }
            else
            {
                hostName = "127.0.0.1";
            }
            Server server = new Server
            {
                Services = { Greeter.BindService(new DemoServerImpl()) },
                Ports = { new ServerPort(hostName, PORT, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine("Greeter server listening on port " + PORT);
            Console.WriteLine("Press any key to stop the server ...");


            string flag = Console.ReadKey().Key.ToString();
            server.ShutdownAsync().Wait();
        }
    }
}

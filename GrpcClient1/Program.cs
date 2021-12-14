using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcServer1;
using System;
using System.Net.Http;

namespace GrpcClient1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });

            var client = new Greeter.GreeterClient(channel);
            var response = client.SayHello(new HelloRequest { Name = ".NET" });

            Console.WriteLine(response.Message);
            Console.Read();
        }
    }
}

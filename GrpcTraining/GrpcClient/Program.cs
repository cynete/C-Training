using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System.Dynamic;

namespace GrpcClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of program");

            GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:7052");

            var client = new GrpcTestService.GrpcTestServiceClient(channel);

            HelloRequest request = new HelloRequest() { Name = "JP" };
            HelloReply response = client.SayHello(request);
            Console.WriteLine($"Reply received = {response}");

            HelloRequest request1 = new HelloRequest() { Name = "Prakash" };
            HelloReply response1 = client.SayHello(request1);
            Console.WriteLine($"Reply received = {response1}");
            Console.WriteLine("-----------------------------------------------");

            var EmployeeIdReq = new EmployeeIdRequest() { Id = 3 };
            EmployeeDetailResponse response2 = client.GetEmployeeByID(EmployeeIdReq);
            Console.WriteLine($"ID = {response2.Id}");
            Console.WriteLine($"Name = {response2.Name}");
            Console.WriteLine($"Age = {response2.Age}");
            Console.WriteLine($"City = {response2.City}");
            Console.WriteLine("-----------------------------------------------");

            // Repeated response >> sends multiple response like array/list
            var AllEmployeeResponse = client.GetAllEmployees(new Empty());
            foreach (var employee in AllEmployeeResponse.EmployeeDetail)
            {
                Console.WriteLine($"ID = {employee.Id}");
                Console.WriteLine($"Name = {employee.Name}");
                Console.WriteLine($"Age = {employee.Age}");
                Console.WriteLine($"City = {employee.City}");
                Console.WriteLine("=====================");
            }
            Console.WriteLine("-----------------------------------------------");

            //Stream >> sends reponse like a stream continuously
            ReadStreamData();



            Console.WriteLine("End of program");

            Console.ReadLine();
        }

        static async void ReadStreamData()
        {
            try
            {

                GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:7052");

                var client = new GrpcTestService.GrpcTestServiceClient(channel);

                Console.WriteLine("Stream Started.");
                var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(20));
                using var streamingCall = client.GetAllEmployeesAsStream(new Empty(), cancellationToken: cancellationToken.Token);

                await foreach (var employee in streamingCall.ResponseStream.ReadAllAsync(cancellationToken: cancellationToken.Token))
                {
                    Console.WriteLine(employee);

                    //if (employee.Name == "Emp3")
                    //    cancellationToken.Cancel();
                }

                Console.WriteLine("Stream completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured = {ex}");
            }

        }
    }
}

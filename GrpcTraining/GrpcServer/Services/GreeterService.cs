using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcServer;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GrpcServer.Services
{
    public class GrpcService : GrpcTestService.GrpcTestServiceBase
    {
        private List<Employee> AllEmployees = new List<Employee>() {
        new Employee() { Id = 1,Name = "Emp1", Age=10,City="Loc1"},
        new Employee() { Id = 2,Name = "Emp2", Age=20,City="Loc2"},
        new Employee() { Id = 3,Name = "Emp3", Age=30,City="Loc3"},
        new Employee() { Id = 4,Name = "Emp4", Age=40,City="Loc4"},
        new Employee() { Id = 5,Name = "Emp5", Age=50,City="Loc5"},
        new Employee() { Id = 6,Name = "Emp6", Age=60,City="Loc6"}
            };

        private readonly ILogger<GrpcService> _logger;
        public GrpcService(ILogger<GrpcService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"This is information ####### request received from {request.Name}");
            _logger.LogInformation(context.ToString());
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<EmployeeDetailResponse> GetEmployeeByID(EmployeeIdRequest request, ServerCallContext context)
        {
            var employee = AllEmployees.Where(e => e.Id == request.Id).FirstOrDefault();

            if (employee != null)
                return Task.FromResult(new EmployeeDetailResponse
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    City = employee.City
                });
            else
                return Task.FromResult(new EmployeeDetailResponse
                {
                    Id = 0,
                    Name = "",
                    Age = 0,
                    City = ""
                });
        }

        // Repeated response >> sends multiple response like array/list
        public override Task<AllEmployeeDetailsResponse> GetAllEmployees(Empty request, ServerCallContext context)
        {
            var respones = new AllEmployeeDetailsResponse();

            foreach (var employee in AllEmployees)
            {
                respones.EmployeeDetail.Add(new EmployeeDetailResponse
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    City = employee.City
                });
            }

            return Task.FromResult(respones);
        }


        //Stream >> sends reponse like a stream continuously
        public override async Task GetAllEmployeesAsStream(Empty request, IServerStreamWriter<EmployeeDetailResponse> streamWriter, ServerCallContext context)
        {

            foreach (var employee in AllEmployees)
            {
                await streamWriter.WriteAsync(new EmployeeDetailResponse
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    City = employee.City
                });
                await Task.Delay(3000);
            }

            //Thread.Sleep(1000);
        }
    }
}

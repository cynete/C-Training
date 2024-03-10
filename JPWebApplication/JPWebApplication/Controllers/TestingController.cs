using JPWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        IEmployeeModel empmodel;
        IEmployeeModel empmodel2;

        public TestingController(IEmployeeModel emp)
        {
            empmodel = emp;
            empmodel2 = emp;
        }

        [HttpPost("{name}")]
        public IActionResult AddEmployee(string name)
        {
            var newId = empmodel.Add(name);
            return Ok(empmodel2.Get(newId));
        }

        [HttpGet("Employees/{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            return Ok(empmodel.Get(id));
        }

        [HttpGet("Employees")]
        public IActionResult GetEmployees()
        {
            return Ok(empmodel.GetAll());
        }
    }
}

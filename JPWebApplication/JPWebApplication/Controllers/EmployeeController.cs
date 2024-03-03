using JPWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPWebApplication.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public List<EmployeeModel> GetEmployees()
        {
            return EmpHelper.GetEmployeeList();
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployees(int id)
        {
            if ((id > EmpHelper.EmpCount) || (id == 0)) { return NotFound($"{id} is not available in emp list"); }

            return Ok(EmpHelper.GetEmployeeList().Where(x => x.id == id));
        }

        [HttpPost]
        [Route("{id:int}/{name:alpha}", Name = "NamedRoute")]
        public IActionResult AddEmployee(int id, string name)
        {
            EmpHelper.Add(new EmployeeModel() { id = id, name = name });
            //return Created($"~/{id}/{name}","employeed added");
            //return CreatedAtAction("AddEmployee",new { id = id, name = name},  "employeed added");
            return CreatedAtRoute("NamedRoute", "employee added");
        }

        [HttpGet]
        [Route("/Alter/{id:int}")]
        public ActionResult<EmployeeModel> GetEmployees1(int id)
        {
            if (id == 99) return BadRequest("Bad request - cannot be processed");
            if ((id > EmpHelper.EmpCount) || (id == 0)) { return NotFound($"{id} is not available in emp list"); }

            //return Ok();
            return Ok(EmpHelper.GetEmployeeList().Where(x => x.id == id).FirstOrDefault());
        }

        [HttpGet("~/Alter/[Action]")]
        public ActionResult<EmployeeModel> TestReroute()
        {
            return LocalRedirect("~/api/Employees");
        }
    }
}

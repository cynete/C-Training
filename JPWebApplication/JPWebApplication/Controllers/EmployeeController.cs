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

        [HttpGet]
        [Route("/Alter/{id:int}")]
        public ActionResult<EmployeeModel> GetEmployees1(int id)
        {
            if ((id > EmpHelper.EmpCount) || (id == 0)) { return NotFound($"{id} is not available in emp list"); }

            //return Ok();
            return Ok(EmpHelper.GetEmployeeList().Where(x => x.id == id).FirstOrDefault());
        }
    }
}

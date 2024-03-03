using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BindProperties(SupportsGet = true)]
    public class AnimalsController : ControllerBase
    {
        //[BindProperty]
        public int id { get; set; }
        //[BindProperty]
        public string name { get; set; }

        [HttpPost("add1")]
        public IActionResult Add1(int id, string name)
        {
            return Ok(new { id, name });
        }

        [HttpPost("add2/{id}/{name}")]
        public IActionResult Add2(int id, string name)
        {
            return Ok(new { id, name });
        }

        [HttpPost("add3")]
        public IActionResult Add3(int test)
        {
            return Ok(new { this.id, this.name, test });
        }

        [HttpGet("add4")]
        public IActionResult Add4(int test)
        {
            return Ok(new { this.id, this.name, test });
        }

        [HttpGet("add5/{id}")]
        public IActionResult Add5([FromRoute] int id, string name)
        {
            return Ok(new { id, name });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPWebApplication.Controllers
{
    [Route("values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet(Name = "GetMeValues")]
        public  string GetMeValues()
        {
            return "From values controller = GetMeValues";
        }

        [HttpPost("PostValues")]
        public string PostValues()
        {
            return "From values controller = PostValues";
        }
    }
}

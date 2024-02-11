using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPWebApplication.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet(Name = "GetMeValues")]
        public string GetMeValues()
        {
            return "From values controller = GetMeValues";
        }

        [HttpGet]
        [Route("{message}")]
        [Route("~/DefaultValues")]
        public string GetMeValues2(string message="Default value")
        {
            return $"From values controller = GetMeValues2 - {message}";
        }


        [HttpPost("PostValues")]
        public string PostValues()
        {
            return "From values controller = PostValues";
        }
    }
}

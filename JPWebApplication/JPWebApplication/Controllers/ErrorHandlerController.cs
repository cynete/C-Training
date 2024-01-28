using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPWebApplication.Controllers
{
    [Route("DefaultError")]
    [ApiController]
    public class ErrorHandlerController : ControllerBase
    {
        [HttpGet(Name = "GetError")]
        public string GetError()
        {
            return $"{DateTime.UtcNow.ToString()} - You have hit error. Unsupported request {Request.Path}";
        }
    }
}

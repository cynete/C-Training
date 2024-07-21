
using Serilog;

namespace Solid.Requests
{
    internal class Request : IRequest
    {
        public ILogger _log { get; set; }
        public Actions.AllowedActions Action { get; set; }
        public string JobName { get; set; }
        public string JobParameter { get; set; }
        public int RequestId { get; set; }

        public Request()
        {
            
        }
        public Request(ILogger log)
        {
            _log = log;    
        }
    }
}


using Serilog;

namespace Solid.Requests
{
    internal interface IRequest
    {
        public ILogger _log { get; set; }
        Actions.AllowedActions Action { get; set; }
        string JobName { get; set; }
        string JobParameter { get; set; }
        int RequestId { get; set; }
    }
}
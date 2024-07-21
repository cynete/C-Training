using Serilog;
using Solid.Requests;

namespace Solid
{
    internal class MonitorJobRequest : Request
    {
        public MonitorJobRequest(ILogger log) : base(log)
        {
            _log.Information("Enter request ID: ");
            Action = Actions.AllowedActions.MonitorJob;
            RequestId = int.Parse(Console.ReadLine());
        }
    }
}

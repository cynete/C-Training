using Serilog;
using Solid.Requests;

namespace Solid
{
    internal class MonitorJobRequest : Request
    {
        public MonitorJobRequest()
        {
            Log.Information("Enter request ID: ");
            Action = Actions.AllowedActions.MonitorJob;
            RequestId = int.Parse(Console.ReadLine());
        }
    }
}

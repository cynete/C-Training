using Serilog;
using Solid.Requests;
    

namespace Solid
{
    internal class GetMessageRequest : Request
    {
        public GetMessageRequest(ILogger log) : base(log)
        {
            _log.Information("Enter request ID:");
            Action = Actions.AllowedActions.GetMessage;
            RequestId = int.Parse(Console.ReadLine());
        }
    }
}

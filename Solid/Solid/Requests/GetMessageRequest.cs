using Serilog;
using Solid.Requests;

namespace Solid
{
    internal class GetMessageRequest : Request
    {
        public GetMessageRequest()
        {
            Log.Information("Enter request ID:");
            Action = Actions.AllowedActions.GetMessage;
            RequestId = int.Parse(Console.ReadLine());
        }
    }
}

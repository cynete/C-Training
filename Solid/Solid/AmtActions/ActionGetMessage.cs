using Serilog;
using Solid.AmtActions.interfaces;
using Solid.AMTSimulation.Interface;
using Solid.Requests;

namespace Solid.AmtActions
{
    internal class ActionGetMessage : IAction
    {
        public IRequest _request { get; set; }
        public IComscript _comscript { get; set; }
        public ActionGetMessage(IRequest request, IComscript comscript)
        {
            _comscript = comscript;
            _request = request;
        }
        public void PerformAction()
        {
            var result = _comscript.GetMessage(_request.RequestId);

            if (string.IsNullOrEmpty(result))
            {
                Log.Error($"{_request.RequestId} not found in active jobs");
            }
            else
            {
                Log.Information($"Message found for {_request.RequestId} = {result}");
            }
        }
    }
}

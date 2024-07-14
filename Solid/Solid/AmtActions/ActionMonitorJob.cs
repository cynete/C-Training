using Serilog;
using Solid.AmtActions.interfaces;
using Solid.AMTSimulation.Interface;
using Solid.Requests;

namespace Solid.AmtActions
{
    internal class ActionMonitorJob : IAction
    {
        public IRequest _request { get; set; }
        public IComscript _comscript { get; set; }
        public ActionMonitorJob(IRequest request, IComscript comscript)
        {
            _comscript = comscript;
            _request = request;
        } 
        public void PerformAction()
        {
            var foundJob = _comscript.FindJob(_request.RequestId);

            if (foundJob == null)
                Log.Error($"{_request.RequestId} not found in active jobs");
            else
                Log.Information($"Job found = {foundJob.RequestId} >> {foundJob.JobName} | {foundJob.Parameters}");
        }
    }
}

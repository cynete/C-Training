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
        public ILogger _log { get; set; }
        public ActionMonitorJob(IRequest request, IComscript comscript, ILogger Log)
        {
            _comscript = comscript;
            _request = request;
            _log = Log;
        } 
        public void PerformAction()
        {
            var foundJob = _comscript.FindJob(_request.RequestId);

            if (foundJob == null)
                _log.Error($"{_request.RequestId} not found in active jobs");
            else
                _log.Information($"Job found = {foundJob.RequestId} >> {foundJob.JobName} | {foundJob.Parameters}");
        }
    }
}

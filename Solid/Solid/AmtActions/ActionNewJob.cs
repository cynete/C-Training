using Serilog;
using Solid.AmtActions.interfaces;
using Solid.AMTSimulation.Interface;
using Solid.Requests;

namespace Solid.AmtActions
{
    internal class ActionNewJob : IAction
    {
        public IRequest _request { get; set; }
        public IComscript _comscript { get; set; }
        public ILogger _log { get; set; }
        public ActionNewJob(IRequest request, IComscript comscript, ILogger log)
        {
            _comscript = comscript;
            _request = request;
            _log = log;
        }
        public void PerformAction()
        {
            var job = _comscript.CreateNewJobObject();

            job.JobName = _request.JobName;
            job.Parameters = _request.JobParameter;
            var newReqId = _comscript.CreateJob(job);

            _log.Information($"Created job {job.JobName} = {newReqId}");
        }
    }
}

using Serilog;
using Solid.AmtActions.interfaces;
using Solid.AMTSimulation.Interface;
using Solid.Requests;

namespace Solid.AmtActions
{
    internal class ActionAll : IAction
    {
        public IRequest _request { get; set; }
        public IComscript _comscript { get; set; }
        public ILogger _log { get; set; }
        public ActionAll(IRequest request, IComscript comscript, ILogger log)
        {
            _comscript = comscript;
            _request = request;
            _log = log;
        }
        public void PerformAction()
        {
            //creating new Job
            var job = _comscript.CreateNewJobObject();

            job.JobName = _request.JobName;
            job.Parameters = _request.JobParameter;
            var newReqId = _comscript.CreateJob(job);

            _log.Information($"Created job {job.JobName} = {newReqId}");

            //Monitoring status
            for (var i = 0; i < 5; i++)
            {
                var foundJob = _comscript.FindJob(newReqId);
                _log.Information($"Job found = {foundJob.RequestId} >> {foundJob.JobName} | {foundJob.Parameters}");
                Thread.Sleep(500);
            }

            //Get messages
            var result = _comscript.GetMessage(newReqId);
            _log.Information(result);
        }
    }
}

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
        public ActionNewJob(IRequest request, IComscript comscript)
        {
            _comscript = comscript;
            _request = request;
        }
        public void PerformAction()
        {
            var job = _comscript.CreateNewJobObject();

            job.JobName = _request.JobName;
            job.Parameters = _request.JobParameter;
            var newReqId = _comscript.CreateJob(job);

            Log.Information($"Created job {job.JobName} = {newReqId}");
        }
    }
}

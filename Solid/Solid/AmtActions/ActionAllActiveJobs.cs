using Serilog;
using Solid.AmtActions.interfaces;
using Solid.AMTSimulation.Interface;
using Solid.Requests;

namespace Solid.AmtActions
{
    internal class ActionAllActiveJobs : IAction
    {
        public IRequest _request { get; set; }
        public IComscript _comscript { get; set; }
        public ILogger _log { get; set; }
        public ActionAllActiveJobs(IRequest request, IComscript comscript, ILogger log)
        {
            _comscript = comscript;
            _request = request;
            _log = log;
        }
        public void PerformAction()
        {
            var result = _comscript.GetAllActiveJobs();

            _log.Information("Active jobs are : ");
            foreach (var job in result)
            {
                _log.Information($"{job.RequestId} >> {job.JobName} | {job.Parameters}");
            }
        }
    }
}

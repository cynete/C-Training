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
        public ActionAllActiveJobs(IRequest request, IComscript comscript)
        {
            _comscript = comscript;
            _request = request;
        }
        public void PerformAction()
        {
            var result = _comscript.GetAllActiveJobs();

            Log.Information("Active jobs are : ");
            foreach (var job in result)
            {
                Log.Information($"{job.RequestId} >> {job.JobName} | {job.Parameters}");
            }
        }
    }
}

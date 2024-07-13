using Serilog;
using Solid.AMTSimulation;

namespace Solid
{
    internal class Helper
    {
        public void PerformAction(Request request)
        {
            switch (request.Action)
            {
                case Actions.AllowedActions.NewJobRequest:
                    {
                        var comX = new Comscript();
                        var job = comX.CreateNewJobObject();

                        job.JobName = request.JobName;
                        job.Parameters = request.JobParameter;
                        var newReqId = comX.CreateJob(job);

                        Log.Information($"Created job {job.JobName} = {newReqId}");

                        break;
                    }

                case Actions.AllowedActions.MonitorJob:
                    {
                        var comX = new Comscript();
                        var foundJob = comX.FindJob(request.RequestId);

                        if (foundJob == null)
                            Log.Error($"{request.RequestId} not found in active jobs");
                        else
                            Log.Information($"Job found = {foundJob.RequestId} >> {foundJob.JobName} | {foundJob.Parameters}");
                        break;
                    }

                case Actions.AllowedActions.GetMessage:
                    {
                        var comX = new Comscript();
                        var result = comX.GetMessage(request.RequestId);

                        if (string.IsNullOrEmpty(result))
                        {
                            Log.Error($"{request.RequestId} not found in active jobs");
                        }
                        else
                        {
                            Log.Information($"Message found for {request.RequestId} = {result}");
                        }
                        break;
                    }

                case Actions.AllowedActions.All:
                    {
                        //creating new Job
                        var comX = new Comscript();
                        var job = comX.CreateNewJobObject();

                        job.JobName = request.JobName;
                        job.Parameters = request.JobParameter;
                        var newReqId = comX.CreateJob(job);

                        Log.Information($"Created job {job.JobName} = {newReqId}");

                        //Monitoring status
                        for (var i = 0; i < 5; i++)
                        {
                            var foundJob = comX.FindJob(newReqId);
                            Log.Information($"Job found = {foundJob.RequestId} >> {foundJob.JobName} | {foundJob.Parameters}");
                            Thread.Sleep(500);
                        }

                        //Get messages
                        var result = comX.GetMessage(newReqId);
                        Log.Information(result);

                        break;
                    }

                case Actions.AllowedActions.GetAllActiveJobs:
                    {
                        var comX = new Comscript();
                        var result = comX.GetAllActiveJobs();

                        Log.Information("Active jobs are : ");
                        foreach (var job in result)
                        {
                            Log.Information($"{job.RequestId} >> {job.JobName} | {job.Parameters}");
                        }
                        break;
                    }
            }
        }
    }
}

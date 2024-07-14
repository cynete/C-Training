using Serilog;
using Solid.AMTSimulation.Interface;

namespace Solid.AMTSimulation
{
    internal class Comscript : IComscript
    {
        public Comscript()
        {
            Log.Debug("Comscript object created");
        }

        public Job CreateNewJobObject()
        { return new Job(); }

        public int CreateJob(Job NewJob)
        {
            Log.Debug($"Creating new Job =  {NewJob.JobName}");
            while (true)
            {
                var newReqId = new Random().Next(1, 1000);

                if (!MemorySimulation.ActiveJobs.Any(x => x.RequestId == newReqId))
                {
                    NewJob.RequestId = newReqId;
                    break;
                }
            }

            MemorySimulation.ActiveJobs.Add(NewJob);
            return NewJob.RequestId;
        }
        public IEnumerable<Job> GetAllActiveJobs()
        {
            return MemorySimulation.ActiveJobs;
        }

        public Job? FindJob(int requestId)
        {
            Log.Debug($"Finding job = {requestId}");
            return MemorySimulation.ActiveJobs.FirstOrDefault(x => x.RequestId == requestId);
        }

        public string GetMessage(int newReqId)
        {
            Log.Debug($"Getting Message for = {newReqId}");
            if (MemorySimulation.ActiveJobs.Any(x => x.RequestId == newReqId))
            {
                return $"Hello from >> {newReqId}";
            }
            return "";
        }

        public int StopJob(int requestId)
        {
            return MemorySimulation.ActiveJobs.RemoveAll(x => x.RequestId == requestId);
        }
    }
}

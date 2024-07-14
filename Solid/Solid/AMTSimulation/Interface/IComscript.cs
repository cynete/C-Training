namespace Solid.AMTSimulation.Interface
{
    internal interface IComscript
    {
        int CreateJob(Job NewJob);
        Job CreateNewJobObject();
        Job? FindJob(int requestId);
        IEnumerable<Job> GetAllActiveJobs();
        string GetMessage(int newReqId);
        int StopJob(int requestId);
    }
}
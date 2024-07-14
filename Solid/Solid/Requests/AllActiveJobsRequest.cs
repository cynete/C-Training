using Solid.Requests;

namespace Solid
{
    internal class AllActiveJobsRequest : Request
    {
        public AllActiveJobsRequest()
        {
            Action = Actions.AllowedActions.GetAllActiveJobs;
        }
    }
}

using Solid.Requests;

namespace Solid
{
    internal class NewJobRequest : Request
    {
        public NewJobRequest()
        {
            var rand = new Random();
            Action = Actions.AllowedActions.NewJobRequest;
            JobName = "Task-" + rand.Next(1, 100);
            JobParameter = "TaskParam-" + rand.Next(1, 100);
            RequestId = 0;
        }
    }
}

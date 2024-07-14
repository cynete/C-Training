using Solid.Requests;

namespace Solid
{
    internal class AllRequest : Request
    {
        public AllRequest()
        {
            var rand = new Random();
            Action = Actions.AllowedActions.All;
            JobName = "Task-" + rand.Next(1, 100);
            JobParameter = "TaskParam-" + rand.Next(1, 100);
        }
    }
}

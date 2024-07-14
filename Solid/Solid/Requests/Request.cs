namespace Solid.Requests
{
    internal class Request : IRequest
    {
        public Actions.AllowedActions Action { get; set; }
        public string JobName { get; set; }
        public string JobParameter { get; set; }
        public int RequestId { get; set; }
    }
}

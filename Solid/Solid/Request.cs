namespace Solid
{
    internal class Request
    {
        public Actions.AllowedActions Action { get; set; }
        public string JobName { get; set; }
        public string JobParameter { get; set; }
        public int RequestId { get; set; }
    }
}

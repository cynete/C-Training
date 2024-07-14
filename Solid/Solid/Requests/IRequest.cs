namespace Solid.Requests
{
    internal interface IRequest
    {
        Actions.AllowedActions Action { get; set; }
        string JobName { get; set; }
        string JobParameter { get; set; }
        int RequestId { get; set; }
    }
}
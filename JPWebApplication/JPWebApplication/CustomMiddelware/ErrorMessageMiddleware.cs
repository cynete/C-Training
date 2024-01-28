
namespace JPWebApplication.CustomMiddelware
{
    public class ErrorMessageMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("You have hit error page");
        }
    }
}

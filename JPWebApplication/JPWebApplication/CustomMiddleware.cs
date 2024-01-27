
namespace JPWebApplication
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("custom middeleware 1 \n");
            await next(context);
        }
    }
}

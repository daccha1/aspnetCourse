
namespace MiddlewareApp.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("MyCustomMiddleware Instance - Starts");
            await next(context);
            await context.Response.WriteAsync("MyCustomMiddleware Instance - Ends");
        }
    }
}

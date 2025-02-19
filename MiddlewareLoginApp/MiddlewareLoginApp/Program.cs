using Microsoft.Extensions.Primitives;
using MiddlewareLoginApp.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<LoginMiddleware>();
var app = builder.Build();


app.UseMiddleware<LoginMiddleware>();

app.Run(async (HttpContext context) =>
{
    if(context.Response.StatusCode == 200)
    {
        await context.Response.WriteAsync("Login has been successful");
    }
    else
    {
        context.Response.WriteAsync("Login has failed: Invalid credentials");
    }

});

app.Run();

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["myKey"] = "myvalue";
    context.Response.Headers.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>David</h1>");
});

app.Run(); 

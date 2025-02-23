var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    if(endpoint != null)
    {
        await context.Response.WriteAsync($"{endpoint.DisplayName}");
    }
    await next(context);
});


app.UseRouting(); // selects the appropriate endpoints
                  // app.UseEndpoints() executes the appropriate endpoint

app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    if (endpoint != null)
    {
        await context.Response.WriteAsync($"{endpoint.DisplayName}");
    }
    await next(context);
});

app.UseEndpoints(endpoints =>
{
    // mapGet, mapPost, mapMethod => izvrsavaju se kada je poslat zahtev sa tom metodom
    
    endpoints.MapGet("/putanja", async (context) =>
    {
        await context.Response.WriteAsync("Nalazimo se na /putanja putanji");
    });

    endpoints.MapPost("/putanja2", async (context) =>
    {
        await context.Response.WriteAsync("Nalazimo se na /putanja2 putanji");
    });

});



app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Nalazite se na {context.Request.Path} ");
});

app.Run();

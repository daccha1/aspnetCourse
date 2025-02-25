var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

Dictionary<int, string> countries = new Dictionary<int, string> 
{
    {1, "United States" },
    {2, "Canada" },
    {3, "United Kingdom" },
    {4, "India" },
    {5, "Japan" },
};

app.UseEndpoints(endpoints =>
{

    endpoints.MapGet("/countries", async context =>
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync($"1, {countries[1]}\n");
        await context.Response.WriteAsync($"2, {countries[2]}\n");
        await context.Response.WriteAsync($"3, {countries[3]}\n");
        await context.Response.WriteAsync($"4, {countries[4]}\n");
        await context.Response.WriteAsync($"5, {countries[5]}\n");
    });

    endpoints.MapGet("/countries/{countryId:int:range(1,101)}", async context =>
    {
        // range max = 101 just for the test of id>100

        int id = Convert.ToInt32(context.Request.RouteValues["countryId"]);

        if (id > 100)
        {
            context.Response.StatusCode = 400;
            context.Response.Headers["Content-type"] = "text/html";
            await context.Response.WriteAsync("<h4 style=color:red>Country ID should be between 1 and 100</h4>");
            return;
        }
        else if (id < 1 || id > 5)
        {
            context.Response.StatusCode = 404;
            context.Response.Headers["Content-type"] = "text/html";
            await context.Response.WriteAsync("<h4 style=color:red>[No Country]</h4>");
            return;
        }
            
        await context.Response.WriteAsync($"{countries[id]}");
    });

});

app.Run(async context =>
{
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("URL path is wrong, please enter a valid path!");
});

app.Run();

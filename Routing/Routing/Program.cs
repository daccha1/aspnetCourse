var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// FILE CONTAINS MULTIPLE EXERCISES MERGED INTO ONE.
// EACH app.Use(endpoints...) IS A EXERCISE VARIATION


app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    if (endpoint != null)
    {
        await context.Response.WriteAsync($"{endpoint.DisplayName}");
    }
    await next(context);
});


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

app.UseRouting(); // selects the appropriate endpoints


app.UseEndpoints(endpoints =>

{ 
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string filename;
string extension;
if (context.Request.RouteValues["filename"] != null && context.Request.RouteValues["extension"] != null)
{
    filename = Convert.ToString(context.Request.RouteValues["filename"]);
    extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"Ime fajla je: {filename}, ekstenzija fajla je: {extension}");
}

    });
});

app.UseEndpoints(endpoints =>
{
    endpoints.Map("employees/details/{id?}", async context =>
    {
        if (context.Request.RouteValues["id"] == null)
        {
            await context.Response.WriteAsync("ID je NULL, molim Vas prosledite odgovarajucu vrednost");
        }
        else
        {
            int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"ID zaposlenog je {id}");
        }
    });

    endpoints.Map("report-date/{reportdate:datetime?}", async context =>
    {
        if(context.Request.RouteValues["reportdate"] == null)
        {
            await context.Response.WriteAsync("Datum je NULL, unesite validan datum");
            return;
        }
        DateTime date = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"Datum je {date}"); // MM-DD-YYYY
    });

    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityid = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"ID grada je: {cityid}");
    });

    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}/{amount:int:min(999)?}", async context =>
    {
        if(context.Request.RouteValues["year"] != null && context.Request.RouteValues["month"] != null && context.Request.RouteValues["amount"] != null)
        {
            int year = Convert.ToInt32(context.Request.RouteValues["year"]);
            string month = Convert.ToString(context.Request.RouteValues["month"]);
            int amount = Convert.ToInt32(context.Request.RouteValues["amount"]);
            await context.Response.WriteAsync($"Godina je: {year}, mesec je: {month}, iznos je {amount}");
        }
        else
        {
            await context.Response.WriteAsync("Neka vrednost == NULL, unesite drugu vrednost");
        }
    });
});



app.Run(async (context) =>
{
    await context.Response.WriteAsync("Tekst");   
});

app.Run();

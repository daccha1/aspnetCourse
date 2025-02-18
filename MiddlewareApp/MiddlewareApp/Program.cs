using MiddlewareApp.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>(); // instancira se kada se pozove u kodu
var app = builder.Build();

////example1

////middleware 1
//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello");
//});

////middleware 2
//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello again");
//});

//// MW1 ne prosleduje zahtev ka mw2 i app.Run koristimo za takve: kratke MW kada nemamo potrebe za prosledjivanjem zahteva


//example2: middleware chain (MW1->MW2->MW3): mw1 se izvrsi i prosledjuje zahtev mw2, pa kada se mw2 izvrsi prosledjuje ga mw3

app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("From Middleware 1");
    await next(context);
});

app.UseMiddleware<MyCustomMiddleware>();


app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("From Middleware 3");
});






app.Run();

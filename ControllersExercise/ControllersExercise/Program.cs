var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddTransient<ControllerName>();
builder.Services.AddControllers();


var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();

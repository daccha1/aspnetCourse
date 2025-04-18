using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.Add(new ServiceDescriptor(
		typeof(ICitiesService),
		typeof(CitiesService),
		ServiceLifetime.Transient
	));

var app = builder.Build();
app.UseStaticFiles(); // static content
app.UseRouting(); // routing
app.MapControllers(); // mapping the controllers


app.Run();

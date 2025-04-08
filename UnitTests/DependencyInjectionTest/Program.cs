using DependencyInjectionTest.Models;
using DependencyInjectionTest.Contracts;
using DependencyInjectionTest.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.Add(new ServiceDescriptor(
	typeof(IMehanicarContract),
	typeof(MehanicarService),
	ServiceLifetime.Transient
	));

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.MapControllers();



app.Run();

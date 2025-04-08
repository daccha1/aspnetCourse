using DependencyInjectionTest.Models;
using DependencyInjectionTest.Contracts;
using DependencyInjectionTest.Services;
using Microsoft.EntityFrameworkCore;
using Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.Add(new ServiceDescriptor(
	typeof(IMehanicarContract),
	typeof(MehanicarService),
	ServiceLifetime.Transient
	));

builder.Services.AddDbContext<PersonDbContext>(
	options=>
	{
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	});

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.MapControllers();



app.Run();

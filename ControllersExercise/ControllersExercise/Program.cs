<<<<<<< HEAD
using ControllersExercise.Controllers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ControllersExercise.Models;

namespace ControllersExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<AdminPermissions>();
            builder.Services.AddControllers();
            var app = builder.Build();
            
            
            app.UseRouting();
            app.MapControllers();

            //AdminPermissions admin = new AdminPermissions(true, true);

            //// checks if admin permissions are allowed
            //app.Use(async (HttpContext context, RequestDelegate next) =>
            //{
            //    string path = context.Request.Path;
            //    if (path.Contains("admin"))
            //    {
            //        bool[] config = admin.adminConfiguration();

            //        if (config[0] == true && config[1] == true)
            //        {
            //            await next(context);
            //        }
            //        else
            //        {
            //            context.Response.StatusCode = 400;
            //            await context.Response.WriteAsync("Nemate adminske permisije da pristupite ovoj stranici");
            //            return;
            //        }

            //    }
            //    else
            //    {
            //        await next(context);
            //    }
            //});


            //app.Use(async (HttpContext context, RequestDelegate next) =>
            //{
            //    bool[] config = admin.adminConfiguration();
            //    if(context.Request.Method == "GET")
            //    {
            //        if(context.Request.Path == "/products/update-stock")
            //        {
            //            if (config[0] == true && config[1] == true)
            //            { 
            //             await next(context);
            //            }
            //            else
            //            {
            //                await context.Response.WriteAsync("Nemate adminsku dozvolu da izmenite stanje");
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //});





            app.MapGet("/", async (context) => 
            {
                await context.Response.WriteAsync($"Nalazite se na {context.Request.Path} putanji");
            });

            app.Run();
        }
    }
}
=======
var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddTransient<ControllerName>();
builder.Services.AddControllers();


var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

app.Run();
>>>>>>> 3906903ee387364f5421fee0a04b8fc6f2131d64

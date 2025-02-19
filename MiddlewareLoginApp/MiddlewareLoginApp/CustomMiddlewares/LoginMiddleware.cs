using System.IO;
using Microsoft.Extensions.Primitives;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
namespace MiddlewareLoginApp.CustomMiddlewares
{
    public class LoginMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            StreamReader reader = new StreamReader(context.Request.Body);
            string body = await reader.ReadToEndAsync(); // Reading the body of the request and storing it after in variable body

            Dictionary<string, StringValues> queryDictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

            string? email = null;
            string? password = null;

            if (!queryDictionary.ContainsKey("email") || !queryDictionary.ContainsKey("password"))
            {
                context.Response.StatusCode = 400;
                await next(context);
                return;
            }
            else
            {
                email = Convert.ToString(queryDictionary["email"][0]);
                password = Convert.ToString(queryDictionary["password"][0]);
            }


            if (email == "admin@example.com" && password == "admin1234")
            {
                context.Response.StatusCode = 200;
                await next(context);
                return;
            }
            else
            {
                context.Response.StatusCode = 400;
                await next(context);
            }


        }
    }
}



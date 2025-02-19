using System.IO;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    int firstNumber;
    int secondNumber;
    string operation;

    int invalidFirst = 0;
    int invalidSecond = 0;
    int invalidOperation = 0;

    if (context.Request.Query.ContainsKey("firstNumber")) 
    { }
    else
    {
        context.Response.StatusCode = 400;
        invalidFirst = 1;
        await context.Response.WriteAsync("Invalid input for 'firstNumber' \n");
    }

    if (context.Request.Query.ContainsKey("secondNumber"))
    { }
    else
    {
        context.Response.StatusCode = 400;
        invalidSecond = 1;
        await context.Response.WriteAsync("Invalid input for 'secondNumber' \n");
    }

    if (context.Request.Query.ContainsKey("operation"))
    { }
    else
    {
        context.Response.StatusCode = 400;
        invalidOperation = 1;
        await context.Response.WriteAsync("Invalid input for 'operation' \n");
    }

    if(invalidFirst == 1 || invalidSecond == 1|| invalidOperation == 1)
    {
        return;
    }

    firstNumber = int.Parse(context.Request.Query["firstNumber"]);
    secondNumber = int.Parse(context.Request.Query["secondNumber"]);

    if (context.Request.Query["operation"] == "add")
    {
        await context.Response.WriteAsync($"{firstNumber + secondNumber}");
        context.Response.StatusCode = 200;
        return;
    }
    else if(context.Request.Query["operation"] == "subtraction")
    {
        await context.Response.WriteAsync($"{firstNumber - secondNumber}");
        context.Response.StatusCode = 200;
        return;
    }
    else if (context.Request.Query["operation"] == "multiply")
    {
        await context.Response.WriteAsync($"{firstNumber * secondNumber}");
        context.Response.StatusCode = 200;
        return;
    }
    else if (context.Request.Query["operation"] == "divide")
    {
        if(secondNumber == 0)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Dividing by 0 recognized. Please change the input value.");
        }
        await context.Response.WriteAsync($"{firstNumber / secondNumber}");
        context.Response.StatusCode = 200;
        return;
    }
    else if (context.Request.Query["operation"] == "modulo")
    {
        await context.Response.WriteAsync($"{firstNumber % secondNumber}");
        context.Response.StatusCode = 200;
        return;
    }

});

app.Run();

using asp_lrs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<RoutingMiddleware>();
app.Run();

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];

        if (string.IsNullOrWhiteSpace(token))
        {
            context.Response.StatusCode = 403;
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next.Invoke(context);

        if (context.Response.StatusCode == 403)
        {
            await context.Response.WriteAsync("Access Denied");
        }
        else if (context.Response.StatusCode == 404)
        {
            await context.Response.WriteAsync("Not Found");
        }
    }
}
public class RoutingMiddleware
{
    private readonly RequestDelegate _next;

    public RoutingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string path = context.Request.Path;
        var response = context.Response;
        var random = new Random();
        int randomNumber = random.Next(0, 101);
        var company = new Company
        {
            Name = "ASP_THE_BEST",
            Industry = "ASP_COMPANY",
            Location = "Mohyla"
        };
        if (path == "/company")
            await context.Response.WriteAsync($"Info about my class:\n{company.GetAllProperties()}");
        else if (path == "/random"){ 
            await context.Response.WriteAsync($"Random Number: {randomNumber}");
        }
        else
        {
            context.Response.StatusCode = 404;
        }
    }
}



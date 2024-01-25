namespace FilmWebApi;

public class MobileUserAgentMiddleware
{
    private readonly RequestDelegate _next;

    public MobileUserAgentMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userAgent = context.Request.Headers["User-Agent"].ToString();

        if (!userAgent.Contains("Mobile"))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("This service only accepts requests from mobile user agents.");
            return;
        }

        await _next(context);
    }
}

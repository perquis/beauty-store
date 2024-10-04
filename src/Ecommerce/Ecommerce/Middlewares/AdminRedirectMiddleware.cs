public class AdminRedirectMiddleware
{
    private readonly RequestDelegate _next;

    public AdminRedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var user = context.User;

        if (user.Identity!.IsAuthenticated)
        {
            if (user.IsInRole("Admin"))
            {
                if (!context.Request.Path.StartsWithSegments("/Dashboard"))
                {
                    context.Response.Redirect("/Dashboard");
                    return;
                }
            }
        }

        await _next(context);
    }
}

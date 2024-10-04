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
        var request = context.Request;
        var response = context.Response;

        if (user.Identity!.IsAuthenticated)
        {
            if (user.IsInRole("Admin"))
            {
                if (!request.Path.StartsWithSegments("/Dashboard"))
                {
                    response.Redirect("/Dashboard");
                    return;
                }
            }
        }

        await _next(context);
    }
}

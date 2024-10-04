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
            var path = request.Path;

            if (path.StartsWithSegments("/Identity") || path.StartsWithSegments("/Account"))
            {
                await _next(context);
                return;
            }

            if (user.IsInRole("Admin"))
            {
                var isAdminPath = !path.StartsWithSegments("/Dashboard");

                if (isAdminPath)
                {
                    response.Redirect("/Dashboard");
                    return;
                }
            }
        }

        await _next(context);
    }
}

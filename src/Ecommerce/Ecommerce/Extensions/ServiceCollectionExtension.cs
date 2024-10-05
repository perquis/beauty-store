namespace Ecommerce.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<AdminRedirectMiddleware>();
        }
    }
}

using Owin;

namespace SecretsFrameworkApp.Web.Infrastructure
{
    public static class IAppBuilderExtensions
    {
        public static void UseSecurityHeaders(this IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Feature-Policy", new[] { "accelerometer 'none'; camera 'none'; geolocation 'none'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'" });
                context.Response.Headers.Add("X-Content-Type-Options", new[] { "nosniff" });
                context.Response.Headers.Add("X-Frame-Options", new[] { "SAMEORIGIN" });
                context.Response.Headers.Add("X-XSS-Protection", new[] { "1; mode=block" });
                context.Response.Headers.Add("Referrer-Policy", new[] { "strict-origin" });
                await next();

                
            });
        }
    }
}
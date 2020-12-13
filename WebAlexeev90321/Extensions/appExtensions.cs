using Microsoft.AspNetCore.Builder;
using WebAlexeev90321.Middleware;


namespace WebAlexeev90321.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
       IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}

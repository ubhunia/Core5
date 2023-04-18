using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Core5
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyOwnMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public MyOwnMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("MyOwnMiddlewareLogger");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("My middle ware is running..");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyOwnMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyOwnMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyOwnMiddleware>();
        }
    }
}

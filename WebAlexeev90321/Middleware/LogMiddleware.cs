using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;

namespace WebAlexeev90321.Middleware
{
    public class LogMiddleware
    {
        RequestDelegate _next;
        ILogger<LogMiddleware> _logger;
        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode != StatusCodes.Status200OK)
            {
                var path = context.Request.Path +
                context.Request.QueryString;
                _logger.LogInformation($"Request {path} returns status code { context.Response.StatusCode.ToString()}");
            }
        }

    }
}

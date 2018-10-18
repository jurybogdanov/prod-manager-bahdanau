using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProductionManager.Services;

namespace ProductionManager.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly ILoggerService _logger;
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
           _logger.LogError(exception.Message, exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var result = JsonConvert.SerializeObject(new
            {
                error = exception.Message
            });

            return context.Response.WriteAsync(result);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Identity.Api.Middlewares
{
    public class GlobalExceptionHandLingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        public GlobalExceptionHandLingMiddleware(ILogger logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                     Status = (int)HttpStatusCode.InternalServerError,
                     Type = "Server error",
                     Title = "Server error",
                     Detail = "An internal server has occured"
                };

                string json = JsonSerializer.Serialize(problem);

                await context.Response.WriteAsync(json);

                context.Response.ContentType = "application/json";
            }
        }
    }
}

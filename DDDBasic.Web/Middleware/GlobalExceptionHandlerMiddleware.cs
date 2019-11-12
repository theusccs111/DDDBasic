using DDDBasic.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DDDBasic.Web.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
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
                _logger.LogError($"Unexpected error: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            object json;

            if (exception is ValidationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                json = new
                {
                    context.Response.StatusCode,
                    exception.Message
                };

                return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            }

            //other
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            //if (exception is HttpResponseException httpResponseException)
            //{
            //    context.Response.StatusCode = httpResponseException.StatusCode;
            //    json = new
            //    {
            //        context.Response.StatusCode,
            //        Message = ReasonPhrases.GetReasonPhrase(context.Response.StatusCode)
            //    };

            //    return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            //}

            json = new
            {
                context.Response.StatusCode,
                exception.Message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}

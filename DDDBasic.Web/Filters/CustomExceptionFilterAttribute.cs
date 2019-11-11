using DDDBasic.Application.Base;
using DDDBasic.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DDDBasic.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                var validationException = (ValidationException)context.Exception;
                IDictionary<string, string[]> failures = validationException.Failures;
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new ResultApi<IDictionary<string, string[]>>(failures["ExcecaoCapex"]));
                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;

            }

            //if (context.Exception is NotAuthorizedException)
            //{
            //    code = HttpStatusCode.Unauthorized;
            //}

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new ResultApi<string[]>(new[] { context.Exception.Message }, context.Exception.Message));
        }
    }
}

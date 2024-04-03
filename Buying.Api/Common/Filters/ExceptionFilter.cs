using System.Net;
using Buying.Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Buying.Api.Common.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is ValidationException validationException)
            {
                var errors = validationException.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(e => e.Key, e => e
                    .Select(e => e.ErrorMessage)
                    .ToList());

                context.Result = new JsonResult(errors);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exception is NotFoundException)
            {
                context.Result = new JsonResult(exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (exception is BadRequestException)
            {
                context.Result = new JsonResult(exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                if (_hostEnvironment.IsDevelopment())
                    return;

                context.Result = new JsonResult("An error occurred, Please try again.");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
        }
    }
}
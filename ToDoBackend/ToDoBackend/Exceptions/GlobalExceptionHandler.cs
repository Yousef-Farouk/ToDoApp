using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace Todo.WebApi.Exceptions
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = exception switch
            {
                KeyNotFoundException => CreateProblemDetails(
                    HttpStatusCode.NotFound,
                    "Resource not found",
                    exception.Message
                    ),

                ValidationException => CreateProblemDetails(
                    HttpStatusCode.BadRequest,
                    "Validation error",
                    exception.Message
                    ),

                _ => CreateProblemDetails(
                    HttpStatusCode.InternalServerError,
                    "Server error",
                    "An unexpected error occurred"
                )
            };

          

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }


        private static ProblemDetails CreateProblemDetails(
          HttpStatusCode statusCode,
          string title,
          string detail
          )
        {
            return new ProblemDetails
            {
                Status = (int)statusCode,
                Title = title,
                Detail = detail,
            };
        }

    }
}

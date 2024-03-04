using Microsoft.AspNetCore.Mvc;
using PermissionManagement.Application.Exceptions;

namespace PermissionManagement.API.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var exceptionDetails = GetExceptionDetails(ex);
                var problemDetails = new ProblemDetails
                {
                    Status = exceptionDetails.Status,
                    Type = exceptionDetails.Type,
                    Title = exceptionDetails.Title,
                    Detail = exceptionDetails.Detail
                };

                if (exceptionDetails.Errors is not null)
                {
                    problemDetails.Extensions["errors"] = exceptionDetails.Errors;
                }

                context.Response.StatusCode = exceptionDetails.Status;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }

        private static ExceptionDetails GetExceptionDetails(Exception ex)
        {
            return ex switch
            {
                ValidationException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Validacion de Error",
                    "Error de validacion",
                    validationException.Errors
                ),
                _ => new ExceptionDetails(
                    StatusCodes.Status500InternalServerError,
                    "ServerError",
                    "Error de Servidor",
                    "Un inesperado en la App",
                    null
                )

            };
        }

        internal record ExceptionDetails(
            int Status,
            string Type,
            string Title,
            string Detail,
            IEnumerable<object>? Errors
        );
    }
}

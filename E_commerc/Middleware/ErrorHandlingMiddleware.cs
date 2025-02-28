using E_commerce_product_catalog.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Tasks;
using E_commerce.Identity.Exceptions;

namespace E_commerc.Middleware
{

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Default values for ProblemDetails
            var problemDetails = new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception.Message, // Optionally remove this in production
                Instance = context.TraceIdentifier,
            };

            // Customize ProblemDetails based on exception type
            switch (exception)
            {
                case E_commerce.Identity.Exceptions.UnauthorizedAccessException:
                    problemDetails.Title = exception.Message;
                    problemDetails.Status = (int)HttpStatusCode.Unauthorized;
                    problemDetails.Type = nameof(E_commerce.Identity.Exceptions.UnauthorizedAccessException);
                    break;

                case AuthenticationException:
                    problemDetails.Title = exception.Message;
                    problemDetails.Status = (int)HttpStatusCode.Unauthorized;
                    problemDetails.Type = nameof(AuthenticationException);
                    break;

                case ChangePasswordException ex:
                    problemDetails.Title = exception.Message;
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    problemDetails.Type = nameof(ChangePasswordException);
                    problemDetails.Extensions = ex.Errors?.ToDictionary(x => x.Code, object? (x) => x.Description) ??
                                                problemDetails.Extensions;
                    break;

                case IdentityException ex:
                    problemDetails.Title = exception.Message;
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Type = nameof(IdentityException);
                    problemDetails.Extensions = ex.Errors?.ToDictionary(x => x.Code, object? (x) => x.Description) ??
                                                problemDetails.Extensions;
                    break;

                case ArgumentNullException:
                case ArgumentException:
                    problemDetails.Title = "Invalid request data.";
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Type = nameof(ArgumentException);
                    break;

                case KeyNotFoundException:
                    problemDetails.Title = "Resource not found.";
                    problemDetails.Status = (int)HttpStatusCode.NotFound;
                    problemDetails.Type = nameof(KeyNotFoundException);
                    break;
                
            }

            // Set response details
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = problemDetails.Status.Value;

            // Serialize the ProblemDetails object to JSON
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var result = JsonSerializer.Serialize(problemDetails, options);
            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}

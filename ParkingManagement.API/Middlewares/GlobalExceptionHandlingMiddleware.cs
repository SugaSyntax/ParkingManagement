using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Core.Exceptions;

namespace ParkingManagement.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) => _logger = logger;
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(FluentValidation.ValidationException ve)
            {
                _logger.LogError(ve, ve.Message);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Type = "Invalid Data",
                    Title = "Invalid Data",
                    Detail = ve.Message
                };
                string json = JsonSerializer.Serialize(problem);
                context.Response.ContentLength = json.Length;
                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
            catch(BadRequestException bre)
            {
                 _logger.LogError(bre, bre.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Type = "Bad Request",
                    Title = "Bad Request",
                    Detail = bre.Message
                };
                string json = JsonSerializer.Serialize(problem);
                context.Response.ContentLength = json.Length;
                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
            catch (NotFoundException nfe)
            {
                _logger.LogError(nfe, nfe.Message);
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Type = "Not Found",
                    Title = "Not Found",
                    Detail = nfe.Message
                };
                string json = JsonSerializer.Serialize(problem);
                context.Response.ContentLength = json.Length;
                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Error",
                    Title = "Error",
                    Detail = e.Message
                };
                string json = JsonSerializer.Serialize(problem);
                context.Response.ContentLength = json.Length;
                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
        }
        //private void creat
    }
}
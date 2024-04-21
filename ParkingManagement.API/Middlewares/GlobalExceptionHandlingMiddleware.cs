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
                bool isSuccess = false;
                string message = "Invalid Data";
                isSuccess = createResponse(ve,context,message);
            }
            catch(BadRequestException bre)
            {
                bool isSuccess = false;
                string message = "Bad Request";
                isSuccess = createResponse(bre,context,message);
            }
            catch (NotFoundException nfe)
            {
                bool isSuccess = false;
                string message = "Not Found";
                isSuccess = createResponse(nfe,context,message);
            }
            catch (Exception e)
            {
                bool isSuccess = false;
                string message = "Error";
                isSuccess = createResponse(e,context,message);
            }
        }
        private bool createResponse(Exception ex, HttpContext context, string messgae)
        {
            bool isComplete = false;
            _logger.LogError(ex, ex.Message);
            switch (ex)
                {
                    case FluentValidation.ValidationException:
                    case BadRequestException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case NotFoundException:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
            ProblemDetails problem = new()
                {
                    Status = context.Response.StatusCode,
                    Type = messgae,
                    Title = messgae,
                    Detail = ex.Message
                };
            string json = JsonSerializer.Serialize(problem);
            context.Response.ContentLength = json.Length;
            context.Response.WriteAsync(json).Wait();
            context.Response.ContentType = "application/json";
            isComplete = true;
            return isComplete;
        }
    }
}
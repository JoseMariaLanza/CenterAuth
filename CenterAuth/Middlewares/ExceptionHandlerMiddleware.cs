using CenterAuth.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CenterAuth.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        public static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ApiResponse response;
            switch (exception)
            {
                case BadHttpRequestException _:
                    response = ApiResponse.CreateResponse(false, exception.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response = ApiResponse.CreateResponse(false, "Server error");
                    context.Response.StatusCode = (int)(HttpStatusCode.InternalServerError);
                    break;
            }

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}

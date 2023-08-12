using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonCoreLayer.Extenions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
                
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Interval Server Error";
            if (e.GetType() == typeof(ValidationException) || e.GetType()==typeof(UnauthorizedAccessException))
            {
                message = e.Message;
            }

            return context.Response.WriteAsync(new ErrorDetails
            {
                Message = message,
                StatusCode= context.Response.StatusCode
            }.ToString());
        }

    }
}

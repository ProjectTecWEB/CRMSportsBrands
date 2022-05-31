using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMSportsBrands.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionResponseWrapper
    {
        private readonly RequestDelegate _next;

        public ExceptionResponseWrapper(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionResponseWrapperExtensions
    {
        public static IApplicationBuilder UseExceptionResponseWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionResponseWrapper>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMSportsBrands.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DemoPracticeExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public DemoPracticeExceptionMiddleware(RequestDelegate next)
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
        
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DemoPracticeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseDemoPracticeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DemoPracticeExceptionMiddleware>();
        }
    }
}

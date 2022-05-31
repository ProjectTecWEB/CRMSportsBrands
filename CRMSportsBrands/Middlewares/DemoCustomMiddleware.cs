using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMSportsBrands.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DemoCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public DemoCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DemoCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseDemoCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DemoCustomMiddleware>();
        }
    }
}

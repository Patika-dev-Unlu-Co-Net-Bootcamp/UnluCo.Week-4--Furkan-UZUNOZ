using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Bank.WEBAPI.Middleware
{
    public class CustomMiddlewarecs
    {
        private readonly RequestDelegate next;

        public CustomMiddlewarecs(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke (HttpContext context)
        {
            Console.WriteLine("Method :" + context.Request.Method + " Path: "+context.Request.Path);
            await this.next(context);
        }
    }
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddlewarecs>();
        }
    }
}

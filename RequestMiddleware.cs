using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string useragent = context.Request.Headers["User-Agent"];
            if (useragent.Contains("Edg") || useragent.Contains("Trident") || useragent.Contains("EdgChromium"))
            {
                await context.Response.WriteAsync("Przegladarka nie jest obslugiwana");
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}

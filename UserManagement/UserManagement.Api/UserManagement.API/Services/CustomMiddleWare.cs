using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.API.Services
{
    public class CustomMiddleWare : IMiddleware
    {
        public CustomMiddleWare()
        {

        }
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("I'm Custom Middleware");
            return next(context);
        }
    }
}

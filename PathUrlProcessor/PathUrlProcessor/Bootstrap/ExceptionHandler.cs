using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace PathUrlProcessor.Bootstrap
{
    public class ExceptionHandler : IExceptionFilter
    {
        private ILogger<ExceptionHandler> Logger { get; }

        public ExceptionHandler(ILogger<ExceptionHandler> logger) { }


        public void OnException(ExceptionContext context)
        {
            //Log complete exception!
            Logger.Log(LogLevel.Error,context.Exception.Message,context.Exception);
            //Only if the environment is DEVELOPMENT display original error message - o/w show general error message!
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                .Equals("development", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Result = new JsonResult(new
                {
                    Code = HttpStatusCode.InternalServerError,
                    context.Exception.Message,
                    context.Exception,
                });
            }
            else
            {
                context.Result = new JsonResult(new
                {
                    Code = HttpStatusCode.InternalServerError,
                    Messsage = "An error has occurred!",
                });
            }
        }
    }
}
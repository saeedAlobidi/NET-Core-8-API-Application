using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRM.Api.Controllers.Common.Middleware
{

    /*
     Editor:saeed
     Message: this class  you can used  if you want to to intercept Middleware or  Global Error Handler
    
    */
    public class CustomMiddleware
    {

        private readonly IMediator _mediator;

        public enum RequestLifecycle { Begin, Finish }
        public record Middleware(HttpContext context, RequestLifecycle requestLifecycle) : INotification;
        public record GlobalErrorHandler(System.Exception exception) : INotification;

        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next, IMediator mediator = null)
        {

            _next = next;
            _mediator = mediator;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            Middleware _notification;
            GlobalErrorHandler _globalErrorHandler;

            try
            {
                _notification = new(context, RequestLifecycle.Begin);
                await _mediator.Publish(_notification);
                await _next(context);
                _notification = new(context, RequestLifecycle.Finish);
                await _mediator.Publish(_notification);

            }
            catch (System.Exception exception)
            {


               
             _globalErrorHandler = new GlobalErrorHandler(exception);
                await _mediator.Publish(_globalErrorHandler);
            }




        }

    }
}

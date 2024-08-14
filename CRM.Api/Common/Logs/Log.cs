
using System.Text;
using System.Text.Json;
using CRM.Api.Controllers.Common.Middleware;
using MediatR;
using static CRM.Api.Controllers.Common.Middleware.CustomMiddleware;
using Microsoft.AspNetCore.Http.Json;


namespace CRM.Api.Controllers.Common.Logs
{
    public class Log : INotificationHandler<CustomMiddleware.Middleware>
    {



        public async Task Handle(CustomMiddleware.Middleware notification, CancellationToken cancellationToken)
        {

            if (notification.requestLifecycle.Equals(RequestLifecycle.Begin))
            { // Log JSON request body if available
                var requestJson = await request(notification);
                Console.WriteLine("Request JSON: " + requestJson);
            }

            if (notification.requestLifecycle.Equals(RequestLifecycle.Finish))
            {

                 
            }
        }

        private static async Task<string> request(CustomMiddleware.Middleware notification)
        {
            string json = "";
            if (notification.context.Request.ContentLength > 0 && notification.context.Request.ContentType == "application/json")
            {
                notification.context.Request.EnableBuffering();
                using (var reader = new StreamReader(notification.context.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    var requestBody = await reader.ReadToEndAsync();
                    notification.context.Request.Body.Position = 0;
                    var requestJson = JsonDocument.Parse(requestBody).RootElement;
                    json = requestJson.ToString();


                }
            }

            return json;
        }
    }
}

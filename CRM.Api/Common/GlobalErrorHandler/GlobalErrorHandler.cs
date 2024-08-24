
using System.Text;
using System.Text.Json;
using CRM.Api.Controllers.Common.Middleware;
using MediatR;
using static CRM.Api.Controllers.Common.Middleware.CustomMiddleware;


namespace CRM.Api.Controllers.Common.GlobalErrorHandler
{
    public class GlobalErrorHandler : INotificationHandler<CustomMiddleware.GlobalErrorHandler>
    {



        public async Task Handle(CustomMiddleware.GlobalErrorHandler notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("exception==> ", notification.exception.Message);

        }

    }
}

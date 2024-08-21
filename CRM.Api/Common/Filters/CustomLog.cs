using Microsoft.AspNetCore.Mvc.Filters;

namespace CRM.Api.Controllers.Common.Filters;


public class CustomLog : IAsyncActionFilter
{
    public CustomLog()
    {
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var resultContext = await next();

    }
}

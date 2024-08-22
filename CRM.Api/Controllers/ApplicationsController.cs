using CRM.Api.Common.Api;
using CRM.Api.Controllers.Common.Mapping;
using CRM.Api.Controllers.Contracts;


using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CRM.Api.Controllers
{
      [ApiController]
      [Route("[controller]")] 
      public class ApplicationsController : ApiController
      {
            public ApplicationsController(ISender mediatR) : base(mediatR)
            {
            }

            [HttpPost(ApiEndpoints.Applications.Create)]

            public async Task<IActionResult> CreateApplication(CreateApplicationRequest request,CancellationToken token)
            {
                  var command = request.MapToApplicationsCommand();
                  var createApplicationResult = await _mediatR.Send(command);

                  return createApplicationResult.Match(Application => Created($"{ApiEndpoints.Applications.Get}?{Application.Id}",Application.MapToResponse()), Problem);

            }


            [HttpGet(ApiEndpoints.Applications.Get)]
            public IActionResult Get(CancellationToken token)
            {
                  return Ok("hi this is saeed1adm ^_^");

            }




      }

}

using CRM.Api.Common.Api;
using CRM.Api.Controllers.Common.Mapping;
using CRM.Api.Controllers.Contracts;


using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CRM.Api.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class ServicesController : ApiController
      {
            public ServicesController(ISender mediatR) : base(mediatR)
            {
            }

            [HttpPost(ApiEndpoints.Services.Create)]
            [Authorize(Policy = "service.read")]
            public async Task<IActionResult> CreateService(CreateServiceRequest request,CancellationToken token)
            {
                  var command = request.MapToServicessCommand();
                  var createServiceResult = await _mediatR.Send(command);


                  return createServiceResult.Match(Service => Created($"{ApiEndpoints.Services.Get}?{Service.Id}", Service.MapToResponse()), Problem);

            }


            [HttpGet(ApiEndpoints.Services.Get)]
            [Authorize(Policy = "service.read")]
            public IActionResult Get(CancellationToken token)
            {
                  return Ok("hi this is saeed ^_^");

            }




      }

}

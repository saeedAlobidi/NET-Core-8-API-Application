using CRM.Api.Common.Api;
using CRM.Api.Controllers.Common.Mapping;
using CRM.Api.Controllers.Contracts;


using MediatR;
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

            public async Task<IActionResult> CreateService(CreateServiceRequest request)
            {
                  var command = request.MapToServicessCommand();
                  var createServiceResult = await _mediatR.Send(command);


                  return createServiceResult.Match(Service => Created($"{ApiEndpoints.Services.Get}?{Service.Id}", Service.MapToResponse()), Problem);

            }


            [HttpGet(ApiEndpoints.Services.Get)]
            public IActionResult Get()
            {
                  return Ok("hi this is saeed ^_^");

            }




      }

}

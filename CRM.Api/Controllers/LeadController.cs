using CRM.Api.Common.Api;
using CRM.Api.Controllers.Common.Filters;
using CRM.Api.Controllers.Common.Mapping;
using CRM.Api.Controllers.Contracts;
using CRM.Leads.Queries.GetLeads;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CRM.Api.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class LeadsController : ApiController
      {
            public LeadsController(ISender mediatR) : base(mediatR)
            {
            }


            [HttpPost(ApiEndpoints.Leads.Create)]
            [ServiceFilter(typeof(CustomLog))]
            public async Task<IActionResult> CreateLead(CreateLeadRequest request)
            {
                  var command = request.MapToLeadsCommand();
                  var createLeadResult = await _mediatR.Send(command);

                  return createLeadResult.Match(lead => Created($"{ApiEndpoints.Leads.Get}?{lead.Id}", lead.MapToResponse()), Problem);

            }


            [HttpGet(ApiEndpoints.Leads.Get)]
            public async Task<IActionResult> Get([FromQuery] int leadId)
            {
                  var command = new GetLeadQuery(leadId);
                  var GetLeadResult = await _mediatR.Send(command);
                  return GetLeadResult.Match(success => Ok(success), Problem);

            }




      }

}

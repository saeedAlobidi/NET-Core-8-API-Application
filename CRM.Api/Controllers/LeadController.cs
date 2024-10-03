using CRM.Api.Common.Api;
using CRM.Api.Controllers.Common.Filters;
using CRM.Api.Controllers.Common.Mapping;
using CRM.Api.Controllers.Contracts;
using CRM.Leads.Queries.GetLeads;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
            [Authorize(Policy = "lead.write")]
            public async Task<IActionResult> CreateLead(CreateLeadRequest request, CancellationToken token)
            {
                  var command = request.MapToLeadsCommand();
                  var createLeadResult = await _mediatR.Send(command);

                  //  return createLeadResult.Match(lead => Created($"{ApiEndpoints.Leads.Get}?{lead.Id}", lead.MapToResponse()), Problem);

                  return null;
            }


            [HttpGet(ApiEndpoints.Leads.Get)]
            [Authorize(Policy = "lead.read")]
            public async Task<IActionResult> Get([FromQuery] int leadId, CancellationToken token)
            {
                  var command = new GetLeadQuery(leadId);
                  var GetLeadResult = await _mediatR.Send(command);
                  return GetLeadResult.Match(success => Ok(success), Problem);

            }

            [HttpGet(ApiEndpoints.Leads.GetById)]
            [Authorize(Policy = "lead.read")]
            public async Task<IActionResult> GetById(int Id, CancellationToken token)
            {
                  var command = new GetLeadQuery(Id);
                  var GetLeadResult = await _mediatR.Send(command);
                  return GetLeadResult.Match(success => Ok(success), Problem);

            }


      }

}

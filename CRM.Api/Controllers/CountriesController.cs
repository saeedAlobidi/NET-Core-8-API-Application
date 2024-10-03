using CRM.Api.Common.Api;
using CRM.Api.Controllers.Common.Filters;
using CRM.Api.Controllers.Common.Mapping;
using CRM.Api.Controllers.Contracts;
using CRM.Leads.Commands.CreateCountry;
using CRM.Leads.Queries.GetLeads;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CRM.Api.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class CountriesController : ApiController
      {
            public CountriesController(ISender mediatR) : base(mediatR)
            {
            }


            [HttpPost(ApiEndpoints.Countries.Create)]
            // [ServiceFilter(typeof(CustomLog))]
            // [Authorize(Policy = "lead.write")]
            [AllowAnonymous]
            public async Task<IActionResult> CreateCountries(CreateCountryCommand request, CancellationToken token)
            { 
                   var command = request.MapToCountriesCommand();
                  
                  var createLeadResult = await _mediatR.Send(command);

                  return createLeadResult.Match(Countriy => Created($"{ApiEndpoints.Leads.Get}?{Countriy.Id}", Countriy.MapToResponse()), Problem);


            }





      }

}

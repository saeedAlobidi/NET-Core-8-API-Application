using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Infrastructure.DTOs.ServicePolicy;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePolicyController : ControllerBase
    {
        private readonly IServicePolicyService _policyContext;
        public ServicePolicyController(IServicePolicyService policy)
        {
            _policyContext = policy;
        }

        // api/ServicePolicy
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var policies = await _policyContext.GetList();
            return Ok(policies);
        }

        // api/ServicePolicy/Save
        [HttpPost("Save")]
        public async Task<IActionResult> Save(ServicePolicyView servicePolicy)
        {
            // valdation the props
            if (ModelState.IsValid)
            {
                // save the data 
                var result = await _policyContext.Create(servicePolicy);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }

            return BadRequest("Ckeck the Fileds");
        }

        // api/ServicePolicy/Delete/{id}
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var policy = await _policyContext.Delete(id);
            return Ok(policy);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Infrastructure.DTOs;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateContext;

        public RateController(IRateService rate)
        {
            _rateContext = rate;
        }

        [HttpGet("GetRateAndCommendBySericeId/{id}")]
        public async Task<IActionResult> GetRateAndCommendBySericeId(long id)
        {
            var _rate = await _rateContext.GetRateAndCommendBySericeId(id);
            return Ok(_rate);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(RateView rate)
        {
            // valdation the props
            if (ModelState.IsValid)
            {
                // save the data 
                var result = await _rateContext.Create(rate);

                // ckeck if it's done return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }

            return BadRequest("Ckeck the Fileds");
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(long id, RateView rate)
        {
            // ckeck if the id is found 
            if (id == 0)
                return BadRequest("Id Not Found");

            // valdation the props
            if (ModelState.IsValid)
            {
                // edit modal
                var result = await _rateContext.Edit(id, rate);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }
            // return the bad req.. 
            return BadRequest("Ckeck the Fileds");
        }
 
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            // send the id to delete the rate 
            var _category = await _rateContext.Delete(id);

            // chcek if it is Succeeded or not
            if (_category.Succeeded)
                return Ok(_category);

            // return bad req...
            return BadRequest(_category.Messages);
        }
    }
}

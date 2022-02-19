using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Infrastructure.DTOs.AvailableService;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableServiceController : ControllerBase
    {

        private readonly IAvailableServiceService _availableServiceContext;
        public AvailableServiceController(IAvailableServiceService availableService)
        {
            _availableServiceContext = availableService;
        }

        //  Get Discount By service Id
        // api/AvailableService/Get/{id}

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var _availableService = await _availableServiceContext.GetAvailableServiceTimeByAvailableServiceId(id);
            return Ok(_availableService);
        }

        // api/AvailableService/Save
        [HttpPost("Save")]
        public async Task<IActionResult> Save(AvailableServiceView availableService)
        {
            // valdation the props
            if (ModelState.IsValid)
            {
                // save the data 
                var result = await _availableServiceContext.Create(availableService);

                // ckeck if it's done 
                // return Succeeded message
                if (! result.Succeeded)
                    return NotFound(result);


                return Ok(result);
            } 

            return BadRequest("Ckeck the Fileds");
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(long id ,AvailableServiceView availableService)
        {
            // ckeck if the id is found 
            if (id == 0)
                return BadRequest("Id Not Found");

            // valdation the props
            if (ModelState.IsValid)
            {
                // edit modal
                var result = await _availableServiceContext.Edit(id, availableService);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }
            // return the bad req.. 
            return BadRequest("Ckeck the Fileds");
        }

        // delete Available Service 
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            // send the id to delete the cateogry 
            var _availableService = await _availableServiceContext.Delete(id);

            // chcek if it is Succeeded or not
            if (_availableService.Succeeded)
                return Ok(_availableService);

            // return bad req...
            return BadRequest(_availableService.Messages);
        } 
        
    }
}

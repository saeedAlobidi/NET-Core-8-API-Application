using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Infrastructure.DTOs.Location;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationContext;
        public LocationController(ILocationService location)
        {
            _locationContext = location;
        }

        // get by id 
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var _location = await _locationContext.GetLocationByServiceId(id);
            return Ok(_location);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(LocationView location)
        {
            var _location = await _locationContext.Create(location);

            if(_location.Succeeded)
                return Ok(_location);

            return NotFound(_location);
        }


        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(long id , LocationView location)
        {
            // ckeck if the id is found 
            if (id == 0)
                return BadRequest("Id Not Found");
            // valdation the props
            if (ModelState.IsValid)
            {
                // edit modal
                var result = await _locationContext.Edit(id, location);

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
            // send the id to delete the _location 
            var _location = await _locationContext.Delete(id);

            // chcek if it is Succeeded or not
            if (_location.Succeeded)
                return Ok(_location);

            // return bad req...
            return BadRequest(_location.Messages);
        }

    }
}

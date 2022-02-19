using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Infrastructure.DTOs.TemporaryReservation;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryReservationController : ControllerBase
    {
        private readonly ITemporaryReservationService _temporaryReservationContext;
        public TemporaryReservationController(ITemporaryReservationService temporaryReservation)
        {
            _temporaryReservationContext = temporaryReservation;
        }
        
        // Get all 
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _temporaryReservation = await _temporaryReservationContext.GetAllTemporaryReservation();
            return Ok(_temporaryReservation);
        }
        
        // Get By user Id
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetTemporaryReservationById(long id)
        {
            var _temporaryReservation = await _temporaryReservationContext.GetTemporaryReservationById(id);
            return Ok(_temporaryReservation);
        }

        // Get By Id
        [HttpGet("GetByUserId/{id}")]
        public async Task<IActionResult> GetTemporaryReservationByUserId(string id)
        {
            var _temporaryReservation = await _temporaryReservationContext.GetTemporaryReservationByUserId(id);
            return Ok(_temporaryReservation);
        }


        // Create
        [HttpPost("Save")]
        public async Task<IActionResult> Save(TemporaryReservationView _tr)
        {
            // valdation the props
            if (ModelState.IsValid)
            {
                // save the data 
                var result = await _temporaryReservationContext.Create(_tr);

                // ckeck if it's done return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }

            return BadRequest("Ckeck the Fileds");
        }

        // Delete  
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            // send the id to delete the cateogry 
            var temporaryReservation = await _temporaryReservationContext.Delete(id);

            // chcek if it is Succeeded or not
            if (temporaryReservation.Succeeded)
                return Ok(temporaryReservation);

            // return bad req...
            return BadRequest(temporaryReservation.Messages);
        }
    }
}

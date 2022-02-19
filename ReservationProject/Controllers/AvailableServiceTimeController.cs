using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Domain.Entities.AvailableServiceTime;
using ReservationProject.Infrastructure.DTOs.AvailableServiceTime;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableServiceTimeController : ControllerBase
    {
        private readonly IAvailableServiceTimeService _availableServiceTimeContext;
        public AvailableServiceTimeController(IAvailableServiceTimeService availableServiceTime)
        {
            _availableServiceTimeContext = availableServiceTime;
        } 

        // edit cateogry
        // api/Cateogry/{id} 

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(long id, AvailableServiceTimeView availableServiceTime)
        {
            // ckeck if the id is found 
            if (id == 0)
                return BadRequest("Id Not Found");
            // valdation the props
            if (ModelState.IsValid)
            {
                // edit modal
                var result = await _availableServiceTimeContext.Edit(id, availableServiceTime);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }
            // return the bad req.. 
            return BadRequest("Ckeck the Fileds");
        }

        // delete cateogry 
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            // send the id to delete the  available Service Time 
            var _category = await _availableServiceTimeContext.Delete(id);

            // chcek if it is Succeeded or not
            if (_category.Succeeded)
                return Ok(_category);

            // return bad req...
            return BadRequest(_category.Messages);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Infrastructure.DTOs.ServiceModal;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceModalController : ControllerBase
    {
        private readonly IServiceModalService _serviceContext;
        public ServiceModalController(IServiceModalService service)
        {
            _serviceContext = service;
        }

        // api/ServiceModal/Get
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var _serviceies = await _serviceContext.GetList();
            return Ok(_serviceies);
        }

        // get serviec by user id 
        [HttpGet("GetServiceByUserId/{userid}")]
        public async Task<IActionResult> GetServiceByUserId(string userid)
        {
            var _serviceies = await _serviceContext.GetServiceByUserId(userid);
            return Ok(_serviceies);
        }

        // get serviec by id
        [HttpGet("GetServiceById/{id}")]
        public async Task<IActionResult> Get(long id )
        {
            var _serviceies = await _serviceContext.GetServiceById(id);
            return Ok(_serviceies);
        }

        // change discount
        [HttpGet("ChangeDiscountStatus/{id}")]
        public async Task<IActionResult> ChangeDiscountStatus(long id)
        {
            var _serviceies = await _serviceContext.ChangeDiscountStatus(id);
            return Ok(_serviceies);
        }

        // lock the serviec 
        [HttpGet("LockService/{id}")]
        public async Task<IActionResult> LockService(long id)
        {
            var _serviceies = await _serviceContext.LockService(id);
            return Ok(_serviceies);
        }

       
        [HttpGet("Delete/{id}")] 
        public async Task<IActionResult> Delete(long id)
        {
            var _serviceies = await _serviceContext.Delete(id);
            return Ok(_serviceies);
        }


        
        // api/ServiceModal/Save
        [HttpPost("Save")]
        public async Task<IActionResult> Save(ServiceModalView service)
        {
            // valdation the props
            if (ModelState.IsValid)
            {
                // save the data 
                var result = await _serviceContext.Create(service);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }

            return BadRequest("Ckeck the Fileds");
        }

        // api/ServiceModal/Edit/{id}
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(long id, ServiceModalView service)
        {
            // ckeck if the id is found 
            if (id == 0)
                return BadRequest("Id Not Found");
            // valdation the props
            if (ModelState.IsValid)
            {
                // edit modal
                var result = await _serviceContext.Edit(id, service);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }
            // return the bad req.. 
            return BadRequest("Ckeck the Fileds");
        }
         
    }
}

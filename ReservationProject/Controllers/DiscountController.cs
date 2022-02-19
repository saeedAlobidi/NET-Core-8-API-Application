using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Infrastructure.DTOs.Discount;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountContext;
        public DiscountController(IDiscountService discount)
        {
            _discountContext = discount;
        }

        //  Get Discount By service Id
        // api/Discount 

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var _discount = await _discountContext.GetDiscountByserviceId(id);
            return Ok(_discount);
        }

        // save the Discount
        // api/Discount
        [HttpPost("Save")]
        public async Task<IActionResult> Save(DiscountView discount)
        {
            // valdation the props
            if (ModelState.IsValid)
            {
                // save the data 
                var result = await _discountContext.Create(discount);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }

            return BadRequest("Ckeck the Fileds");
        }

        //// edit cateogry
        //// api/Discount/Edit/{id} 
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(long id, DiscountView category)
        {
            // ckeck if the id is found 
            if (id == 0)
                return BadRequest("Id Not Found");

            // valdation the props
            if (ModelState.IsValid)
            {
                // edit modal
                var result = await _discountContext.Edit(id, category);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }
            // return the bad req.. 
            return BadRequest("Ckeck the Fileds");
        }

        //// delete Discount 
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            // send the id to delete the cateogry 
            var _discount = await _discountContext.Delete(id);

            // chcek if it is Succeeded or not
            if (_discount.Succeeded)
                return Ok(_discount);

            // return bad req...
            return BadRequest(_discount.Messages);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationProject.Infrastructure.DTOs.Cateogry;
 using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _cateogryContext;
        public CategoryController(ICategoryService cateogry)
        {
            _cateogryContext = cateogry;  
        }
         
        // get all the Cateogries 
        // api/Cateogry
       
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var _cateogries = await _cateogryContext.GetList(); 
            return Ok(_cateogries);
        }

       
        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> GetCateogryById(long id)
        {
            var _cateogry = await _cateogryContext.GetCategoryById(id);
            return Ok(_cateogry);
        }

        [HttpGet("GetCategoryListByCategoryId/{id}")]
        public async Task<IActionResult> GetCateogryListByCateogryId(long id)
        {
            var _cateogries = await _cateogryContext.GetCategoryListByCategoryId(id);
            return Ok(_cateogries);
        }

        // save the cateogry
        // api/Cateogry
        [HttpPost]
        public async Task<IActionResult> Save(CategoryView category)
        {
            // valdation the props
            if (ModelState.IsValid)
            {
                // save the data 
                var result = await _cateogryContext.Create(category);

                // ckeck if it's done 
                // return Succeeded message
                if (result.Succeeded)
                    return Ok(result);
            }

            return BadRequest("Ckeck the Fileds");
        }

        // edit cateogry
        // api/Cateogry/{id} 
        [HttpPost]
        [Route("api/Cateogry/{id}")]
        public async Task<IActionResult> Edit(long id , CategoryView category)
        {
            // ckeck if the id is found 
            if(id == 0)
              return BadRequest("Id Not Found");
            // valdation the props
            if (ModelState.IsValid)
            {
            // edit modal
              var result = await _cateogryContext.Edit(id , category);

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
            // send the id to delete the cateogry 
            var _category = await _cateogryContext.Delete(id);

            // chcek if it is Succeeded or not
            if (_category.Succeeded)
                return Ok(_category);

            // return bad req...
            return BadRequest(_category.Messages);
        }

    }
}

using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.Cateogry;
using ReservationProject.Infrastructure.DTOs.Cateogry;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;

        public CategoryService(IMapper mapper, IUnitOfWork UoW)
        {
            _mapper = mapper;
            _UoW = UoW; 
             //  _localizer = localizer; 
        }

        public async Task<Result<List<CategoryView>>> GetList()
        {
            
            var categories = await _UoW.CategoryRepository.GetAllAsync();

            // map it with mapper 
            var categoriesWithMap = _mapper.Map<List<CategoryView>>(categories);

            // return the reault with seccess message  
            return await Result<List<CategoryView>>.SuccessAsync(categoriesWithMap,"List of Cateogry");
        }


        public async Task<Result<List<CategoryView>>> GetCategoryById(long id)
        {
            // get all cateogries
            var categories = _UoW.CategoryRepository.Entities.Where(c => c.Id == id).ToList();
            
            // ckeck if it null or not 
            if(categories.Count == 0)
                return await Result<List<CategoryView>>.SuccessAsync(null, "The Category with Given Id is Not Exist");

            // map it with mapper 
            var categoriesWithMap = _mapper.Map<List<CategoryView>>(categories);

            // return the reault with seccess message  
            return await Result<List<CategoryView>>.SuccessAsync(categoriesWithMap, "Cateogry Recoreds");
        }

        public async Task<Result<List<CategoryView>>> GetCategoryListByCategoryId(long id)
        {
            // get all cateogries
            var categories = _UoW.CategoryRepository.Entities.Where(c => c.categoryId == id).ToList();

            // map it with mapper 
            var categoriesWithMap = _mapper.Map<List<CategoryView>>(categories);

            // return the reault with seccess message  
            return await Result<List<CategoryView>>.SuccessAsync(categoriesWithMap, "List of Cateogry");
        }

        public async Task<IResult> Create(CategoryView category)
        {
            try
            {
                // map Category View To Category modal 
                var categoryMapper = _mapper.Map<Category>(category);
                
                // add it 
                await _UoW.CategoryRepository.AddAsync(categoryMapper);  
                // save it 
                await _UoW.Commit(new CancellationToken());
                // return with successfully message 
                return await Result.SuccessAsync(message: "created successfully with [ " + category.name + " ]");
            }
            catch
            {
                 await _UoW.Rollback();
                 return Result.Fail(message: "something wrong happened");
            }
        }
        
        public async Task<IResult> Edit(long id, CategoryView category)
        {
            // get the cateogry from databast by id  
            var categoryFromDB = await _UoW.CategoryRepository.GetByIdAsync(id);

            // mapping the CateogryView to Cateogry to make the edit by mapping  
            _mapper.Map<CategoryView, Category>(category, categoryFromDB);  
            // save in database 
            await _UoW.Commit(new CancellationToken());  
            // return the message for done 
            return await Result.SuccessAsync(message: String.Format( "updated successfully" )); 
        } 

        public async Task<IResult> Delete(long id)
        {
            // get the cateogry from database 
            var cateogry = await _UoW.CategoryRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (cateogry != null)
            {
                // change the Isdelete prop
                await _UoW.CategoryRepository.DeleteAsync(cateogry);
                await _UoW.Commit(new CancellationToken());
                // return message with done 
                return await Result.SuccessAsync(message: String.Format(cateogry.name +" is deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The Cateogry with Given Id is Not Exist");
        }
 
    }
}

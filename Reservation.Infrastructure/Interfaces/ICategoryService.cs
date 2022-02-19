using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.Cateogry;
using ReservationProject.Infrastructure.DTOs.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface ICategoryService
    {
        Task<Result<List<CategoryView>>> GetList();
        Task<Result<List<CategoryView>>> GetCategoryListByCategoryId(long id);
        Task<Result<List<CategoryView>>> GetCategoryById(long id);
        Task<IResult> Create(CategoryView input);
        Task<IResult> Edit(long id ,CategoryView input); 
      
        Task<IResult> Delete(long id);
    }
}

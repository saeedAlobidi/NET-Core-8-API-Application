using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.Discount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface IDiscountService
    { 
        Task<Result<List<DiscountView>>> GetDiscountByserviceId(long id);
        Task<IResult> Create(DiscountView input);
        Task<IResult> Edit(long id, DiscountView input); 
        Task<IResult> Delete(long id);
    }
}

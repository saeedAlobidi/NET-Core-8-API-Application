using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.Discount;
using ReservationProject.Infrastructure.DTOs.Discount;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;

        public DiscountService(IMapper mapper, IUnitOfWork UoW)
        {
            _mapper = mapper;
            _UoW = UoW;
            //  _localizer = localizer; 
        }

        public async Task<IResult> Create(DiscountView discount)
        {
            try
            {
                // map discount object 
                var discountMapper = _mapper.Map<Discount>(discount);
                // add discount object 
                await _UoW.DiscountRepository.AddAsync(discountMapper);
                // save object in database  
                await _UoW.Commit(new CancellationToken());
                // return with successfully message 
                return await Result.SuccessAsync(message: "created successfully with [ " + discount.discount + " ]");
            }
            catch
            {
                await _UoW.Rollback();
                return Result.Fail(message: "something wrong happened");
            }
        }

        public async Task<IResult> Delete(long id)
        {
            // get the discount  from database 
            var discount = await _UoW.DiscountRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (discount != null)
            {
                // change the Is delete prop
                await _UoW.DiscountRepository.DeleteAsync(discount);
                await _UoW.Commit(new CancellationToken());

                // return with successfully message 
                return await Result.SuccessAsync(message: String.Format(discount.discount + " is deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The Discount with Given Id is Not Exist");
        }

        public async Task<IResult> Edit(long id, DiscountView discount)
        {
            // get the cateogry from databast by id  
            var discountFromDB = await _UoW.DiscountRepository.GetByIdAsync(id);

            // mapping the CateogryView to Cateogry to make the edit by mapping  
            _mapper.Map<DiscountView, Discount>(discount, discountFromDB);
            // save in database 
            await _UoW.Commit(new CancellationToken());
            // return the message for done 
            return await Result.SuccessAsync(message: String.Format("updated successfully"));
        }

        public async Task<Result<List<DiscountView>>> GetDiscountByserviceId(long id)
        {
            // get all discounts 
            var discount = _UoW.DiscountRepository.Entities.Where(c => c.serviceModalId == id).ToList();

            // ckeck if it null or not 
            if (discount.Count == 0)
                return await Result<List<DiscountView>>.SuccessAsync(null, "The discount with Given Service Id is Not Exist");

            // map it with mapper 
            var discountWithMap = _mapper.Map<List<DiscountView>>(discount);

            // return the reault with seccess message  
            return await Result<List<DiscountView>>.SuccessAsync(discountWithMap, "Discount Recoreds");
        }

    }
}

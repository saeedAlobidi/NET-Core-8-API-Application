using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.Rate;
using ReservationProject.Infrastructure.DTOs;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    public class RateService : IRateService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;

        public RateService(IMapper mapper, IUnitOfWork UoW)
        {
            _mapper = mapper;
            _UoW = UoW;
            //  _localizer = localizer; 
        }

        public async Task<IResult> Create(RateView rateView)
        {
            try
            {
                // map rate View object to rate modal 
                var rateMapper = _mapper.Map<Rate>(rateView);
                // add the object 
                await _UoW.RateRepository.AddAsync(rateMapper);
                // save 
                await _UoW.Commit(new CancellationToken());
                // return with successfully message 
                return await Result.SuccessAsync(message: "created successfully with [ " + rateView.rate + " ]");
            }
            catch
            {
                await _UoW.Rollback();
                return Result.Fail(message: "something wrong happened");
            }
        }

        public async Task<IResult> Delete(long id)
        {
            // get the rate from database 
            var rate = await _UoW.RateRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (rate != null)
            {
                // change the Isdelete prop
                await _UoW.RateRepository.DeleteAsync(rate);
                await _UoW.Commit(new CancellationToken());
                // return message with done 
                return await Result.SuccessAsync(message: String.Format(" deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The Rate with Given Id is Not Exist");
        }


        public async Task<IResult> Edit(long id, RateView rateView)
        {
            // get the rate from databast by id  
            var rateFromDB = await _UoW.RateRepository.GetByIdAsync(id);

            // mapping the RateView to Rate to make the edit by mapping  
            _mapper.Map<RateView, Rate>(rateView, rateFromDB);

            // save in database 
            await _UoW.Commit(new CancellationToken());

            // return the message for done 
            return await Result.SuccessAsync(message: String.Format("updated successfully"));
        }

        public async Task<Result<List<RateView>>> GetRateAndCommendBySericeId(long id)
        {
            // get all rates
            var rates = _UoW.RateRepository.Entities.Where(c => c.Id == id).ToList();

            // ckeck if it null or not 
            if (rates.Count == 0)
                return await Result<List<RateView>>.SuccessAsync(null, "The Rate with Given Id is Not Exist");

            // map it with mapper 
            var ratesWithMap = _mapper.Map<List<RateView>>(rates);

            // return the reault with seccess message  
            return await Result<List<RateView>>.SuccessAsync(ratesWithMap, "Rates Recoreds");
        }

    }
}

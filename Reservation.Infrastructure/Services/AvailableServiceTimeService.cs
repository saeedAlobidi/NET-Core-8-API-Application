using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.AvailableServiceTime;
using ReservationProject.Infrastructure.DTOs.AvailableServiceTime;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    class AvailableServiceTimeService : IAvailableServiceTimeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;

        public AvailableServiceTimeService(IMapper mapper, IUnitOfWork UoW)
        {
            _mapper = mapper;
            _UoW = UoW; 
        }

        public async Task<IResult> Create(AvailableServiceTimeView availableServiceTime)
        {
            try
            {
                // map AvailableServiceTimeView to AvailableServiceTime 
                var availableServiceTimeMapper = _mapper.Map<AvailableServiceTime>(availableServiceTime);

                // add it 
                await _UoW.AvailableServiceTimeRepository.AddAsync(availableServiceTimeMapper);
                // save it 
                await _UoW.Commit(new CancellationToken());
                // return with successfully message 
                return await Result.SuccessAsync(message: "created successfully ");
            }
            catch
            {
                await _UoW.Rollback();
                return Result.Fail(message: "something wrong happened");
            }
        }

        public async Task<IResult> Delete(long id)
        {
            // get the Available Service Time from database 
            var availableServiceTime = await _UoW.AvailableServiceTimeRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (availableServiceTime != null)
            {
                // change the Isdelete prop
                await _UoW.AvailableServiceTimeRepository.DeleteAsync(availableServiceTime);
                await _UoW.Commit(new CancellationToken());
                // return message with done 
                return await Result.SuccessAsync(message: String.Format("deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The Available Service Time with Given Id is Not Exist");
        }

        public async Task<IResult> Edit(long id, AvailableServiceTimeView availableServiceTime)
        {
            // get the Available Service Time from databast by id  
            var availableServiceTimeFromDB = await _UoW.AvailableServiceTimeRepository.GetByIdAsync(id);

            // mapping the AvailableServiceTimeView to AvailableServiceTime to make the edit by mapping  
            _mapper.Map<AvailableServiceTimeView, AvailableServiceTime>(availableServiceTime, availableServiceTimeFromDB);
            // save in database 
            await _UoW.Commit(new CancellationToken());
            // return the successfully message 
            return await Result.SuccessAsync(message: String.Format("updated successfully"));
        }

        public async Task<Result<List<AvailableServiceTimeView>>> GetAvailableServiceTimeByAvailableServiceId(long id)
        {
            // get data
            var availableServiceTime =  _UoW.AvailableServiceTimeRepository.Entities.Where( a => a.availableServiceId == id).ToList();

            // map it with mapper 
            var availableServiceTimeWithMap = _mapper.Map<List<AvailableServiceTimeView>>(availableServiceTime);

            // return the reault with seccess message  
            return await Result<List<AvailableServiceTimeView>>.SuccessAsync(availableServiceTimeWithMap, "Available Service Time");
        }
        
    }
}

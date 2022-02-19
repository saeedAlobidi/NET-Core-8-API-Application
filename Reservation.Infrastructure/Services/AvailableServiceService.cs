using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.AvailableService;
using ReservationProject.Domain.Entities.AvailableServiceTime;
using ReservationProject.Infrastructure.DTOs.AvailableService;
using ReservationProject.Infrastructure.DTOs.AvailableServiceTime;
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
    public class AvailableServiceService : IAvailableServiceService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;
        private readonly IAvailableServiceTimeService _availableServiceTimeService;
        
        private bool _isSaveWithItem;

        public AvailableServiceService(IMapper mapper, IUnitOfWork UoW , IAvailableServiceTimeService availableServiceTimeService)
        {
            _mapper = mapper;
            _UoW = UoW;
            _availableServiceTimeService = availableServiceTimeService;
            _isSaveWithItem = false; 
        }

        public async Task<Result<List<AvailableServiceView>>> GetAvailableServiceTimeByAvailableServiceId(long id)
        {
            // get all availableService by id 
            var availableService = _UoW.AvailableServiceRepository.Entities.Where(c => c.ServiceModalId == id)
                     .Select(a => new AvailableServiceView { 
                        ServiceModalId = a.ServiceModalId,
                        everyWeek = a.everyWeek,
                        id = a.Id,
                        AvailableServiceTimeList = _availableServiceTimeService.GetAvailableServiceTimeByAvailableServiceId(a.Id).Result.Data
                     })
                    .ToList();

            // map it with mapper 
            var availableServiceWithMap = _mapper.Map<List<AvailableServiceView>>(availableService);

            // return the reault with seccess message  
            return await Result<List<AvailableServiceView>>.SuccessAsync(availableServiceWithMap, "List of Available Service Time ");
        }

        public async Task<IResult> Create(AvailableServiceView availableService)
        {
            try
            {
                var availableServiceMapper = _mapper.Map<AvailableService>(availableService);

                await _UoW.AvailableServiceRepository.AddAsync(availableServiceMapper);

                await _UoW.Commit(new CancellationToken());

                if (availableService.AvailableServiceTimeList.Count() != 0)
                     _isSaveWithItem = await SaveAvailableServiceTime(availableService.AvailableServiceTimeList, availableServiceMapper.Id)
                        == true ?  true : false;


                if (!_isSaveWithItem) {
                    await _UoW.Rollback();
                    return await Result.FailAsync(message: "created Filled");
                } 
                
                return await Result.SuccessAsync(message: "created successfully");
 
            }
            catch
            {
                await _UoW.Rollback();
                return Result.Fail(message: "something wrong happened");
            }
        }
         
        private async Task<bool> SaveAvailableServiceTime(IEnumerable<AvailableServiceTimeView> items, long availableServiceId)
        {
            foreach (var item in items)
            {
                item.availableServiceId = availableServiceId;

                // mapping the Service Policy Item
                var ServicePolicyItemMapper = _mapper.Map<AvailableServiceTime>(item);

                // save ServicePolicy
                await _UoW.AvailableServiceTimeRepository.AddAsync(ServicePolicyItemMapper);

                // Commit 
                int IsSaved = await _UoW.Commit(new CancellationToken());

                if (IsSaved != 1)
                    return false; 
            }

            return true;
        }
 
        public async Task<IResult> Delete(long id)
        {
 
            // get the Available Service from database 
            var availableService = await _UoW.AvailableServiceRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (availableService != null)
            {
                // change the Isdelete prop
                await _UoW.AvailableServiceRepository.DeleteAsync(availableService);
 
                await _UoW.Commit(new CancellationToken());
                // return message with done 
                return await Result.SuccessAsync(message: String.Format(" deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The Available Service with Given Id is Not Exist");
        }
         
        public async Task<IResult> Edit(long id, AvailableServiceView availableService)
        { 
            // get the  Available Service from databast by id  
            var availableServiceFromDB = await _UoW.AvailableServiceRepository.GetByIdAsync(id);

            // mapping the  Available ServiceView to  AvailableService to make the edit by mapping  
            _mapper.Map<AvailableServiceView, AvailableService>(availableService, availableServiceFromDB);
  
            // save in database 
            await _UoW.Commit(new CancellationToken());

            // return the message for done 
            return await Result.SuccessAsync(message: String.Format("updated successfully"));
        } 

    }
}

using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.ServiceModal;
using ReservationProject.Infrastructure.DTOs.ServiceModal;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    class ServiceModalService : IServiceModalService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;

        public ServiceModalService(IMapper mapper , IUnitOfWork UoW)
        {
            _mapper = mapper;
            _UoW = UoW;
         // _localizer = localizer; 
        } 


        public async Task<Result<List<ServiceModalView>>> GetList()
        {
            // call the repo class 
            var serviceies = await _UoW.ServiceModalRepository.GetAllAsync();

            // map it with mapper 
            var serviceiesWithMap = _mapper.Map<List<ServiceModalView>>(serviceies);

            // return the reault with seccess message  
            return await Result<List<ServiceModalView>>.SuccessAsync(serviceiesWithMap, "List of Serviceies");
        }

        public async Task<Result<List<ServiceModalView>>> GetServiceById(long id)
        {
            // get all serviceies
            var serviceies = _UoW.ServiceModalRepository.Entities.Where(c => c.Id == id).ToList();

            // map it with mapper 
            var serviceiesWithMap = _mapper.Map<List<ServiceModalView>>(serviceies);

            // return the reault with seccess message  
            return await Result<List<ServiceModalView>>.SuccessAsync(serviceiesWithMap, "List of Serviceies");
        }

        public async Task<Result<List<ServiceModalView>>> GetServiceByUserId(string userid)
        {
            // get all serviceies
            var serviceies = _UoW.ServiceModalRepository.Entities.Where(c => c.serviceProviderId == userid).ToList();

            // map it with mapper 
            var serviceiesWithMap = _mapper.Map<List<ServiceModalView>>(serviceies);

            // return the reault with seccess message  
            return await Result<List<ServiceModalView>>.SuccessAsync(serviceiesWithMap, "List of Serviceies");
        }

        public async Task<IResult> ChangeDiscountStatus(long id)
        {
            // get all serviceies
            var serviceies = _UoW.ServiceModalRepository.Entities.FirstOrDefault(c => c.Id == id);
            // change the has discount status
            serviceies.hasDiscount = true;
            // save it 
            await _UoW.Commit(new CancellationToken());
            // return with successfully mwssage
            return await Result<ServiceModal>.SuccessAsync(serviceies, "Change Discount Status successfully"); 
        }

        public async Task<IResult> Create(ServiceModalView serviceModal)
        {
            try
            {
                var serviceMapper = _mapper.Map<ServiceModal>(serviceModal);

                await _UoW.ServiceModalRepository.AddAsync(serviceMapper);

                await _UoW.Commit(new CancellationToken());

                return await Result.SuccessAsync(message: "created successfully with [ " + serviceModal.name + " ]");
            }
            catch
            {
                await _UoW.Rollback();
                return Result.Fail(message: "something wrong happened");
            }
        }

        public async Task<IResult> Edit(long id, ServiceModalView serviceModal)
        {
            // get the cateogry from databast by id  
            var serviceFromDB = await _UoW.ServiceModalRepository.GetByIdAsync(id);

            // mapping the ServiceModalView to ServiceModal to make the edit by mapping  
            _mapper.Map<ServiceModalView, ServiceModal>(serviceModal, serviceFromDB);
            // save in database 
            await _UoW.Commit(new CancellationToken());
            // return the message for done 
            return await Result.SuccessAsync(message: String.Format("updated successfully"));
        }
 
        public async Task<IResult> Delete(long id)
        {
            // get the cateogry from database 
            var service = await _UoW.ServiceModalRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (service != null)
            {
                // change the Isdelete prop
                await _UoW.ServiceModalRepository.DeleteAsync(service);
                await _UoW.Commit(new CancellationToken());
                // return message with done 
                return await Result.SuccessAsync(message: String.Format(service.name + " is deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The service with Given Id is Not Exist");
        }
 
        public async Task<IResult> LockService(long id)
        {
            // get all serviceies
            var service = _UoW.ServiceModalRepository.Entities.FirstOrDefault(c => c.Id == id);

            service.hasDiscount = true;

            await _UoW.Commit(new CancellationToken());

            return await Result<ServiceModal>.SuccessAsync(service, "The service Locked successfully");
        }
    
    }
}

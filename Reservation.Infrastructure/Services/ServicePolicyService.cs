using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.ServicePolicy;
using ReservationProject.Domain.Entities.ServicePolicyItem;
using ReservationProject.Infrastructure.DTOs.ServicePolicy;
using ReservationProject.Infrastructure.DTOs.ServicePolicyItem;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    public class ServicePolicyService : IServicePolicyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;
        private readonly IServicePolicyItemService _servicePolicyItemService;

        public ServicePolicyService(IMapper mapper, IUnitOfWork UoW , IServicePolicyItemService servicePolicyItemService)
        {
            _mapper = mapper;
            _UoW = UoW;
            _servicePolicyItemService = servicePolicyItemService;
            //  _localizer = localizer; 
        }

        public async Task<Result<List<ServicePolicyView>>> GetList()
        {
            // call the repo class 
            var policies = _UoW.ServicePolicyRepository.Entities.Select(p => new ServicePolicyView
            {
                id = p.Id,
                serviceId = p.serviceId,
                version = p.version,
                items = _UoW.ServicePolicyItemRepository.Entities.Where(po => po.Id == p.Id)
                                           .Select(c => new ServicePolicyItemView
                                           {
                                               id = c.Id,
                                               item = c.item,
                                               servicePolicyId = c.servicePolicyId
                                           }).ToList()
            });

            // map it with mapper 
            var policiesWithMap = _mapper.Map<List<ServicePolicyView>>(policies);

            // return the reault with seccess message  
            return await Result<List<ServicePolicyView>>.SuccessAsync(policiesWithMap, " List of policies ");
        }


        public async Task<IResult> Create(ServicePolicyView servicePolicy)
        {
            try
            {
                // mapping the Service Policy 
                var servicePolicyMapper = _mapper.Map<ServicePolicy>(servicePolicy);
                // save ServicePolicy
                await _UoW.ServicePolicyRepository.AddAsync(servicePolicyMapper);
                // Commit 
                await _UoW.Commit(new CancellationToken());

                // adding Service Policy items
                if(servicePolicy.items.Count() != 0)
                    SaveItem(servicePolicy.items, servicePolicyMapper.Id);


                return await Result.SuccessAsync(message: "created successfully "); 
            }
            catch
            {
                await _UoW.Rollback();
                return Result.Fail(message: "something wrong happened");
            }
        }

        // to save Service Policy Item 
        private async void SaveItem(IEnumerable<ServicePolicyItemView> items , long servicePolicyId)
        {
            foreach (var item in  items)
            {
                item.servicePolicyId = servicePolicyId;
                // mapping the Service Policy Item
                var ServicePolicyItemMapper = _mapper.Map<ServicePolicyItem>(item);
                // save ServicePolicy
                await _UoW.ServicePolicyItemRepository.AddAsync(ServicePolicyItemMapper);
                // Commit 
                await _UoW.Commit(new CancellationToken());
            }
            
        }
        
        
        public async Task<IResult> Delete(long id)
        {
            // get the cateogry from database 
            var policy = await _UoW.ServicePolicyRepository.GetByIdAsync(id);

            // check if the object is null or not 
            if (policy != null)
            {
                // change the Isdelete prop
                await _UoW.ServicePolicyRepository.DeleteAsync(policy);
                await _UoW.Commit(new CancellationToken());
                // return message with done 
                return await Result.SuccessAsync(message: String.Format(policy.version + " is deleted successfully"));
            }
            //  return error message 
            return await Result.FailAsync("The Policy with Given Id is Not Exist");
        }

    }
}

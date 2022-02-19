using AutoMapper;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.ServicePolicyItem;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Services
{
    // public class ServicePolicyService : IServicePolicyService
    public class ServicePolicyItemService : IServicePolicyItemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UoW;

        public ServicePolicyItemService(IMapper mapper, IUnitOfWork UoW)
        {
            _mapper = mapper;
            _UoW = UoW; 
        }

        public Task<IResult> Create(ServicePolicyItemView input)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Edit(long id, ServicePolicyItemView input)
        {
            throw new NotImplementedException();
        } 

        public async Task<Result<List<ServicePolicyItemView>>> GetItemListbyPolicyId(long id)
        {
            var policyItems =  _UoW.ServicePolicyItemRepository.Entities.Where(p => p.servicePolicyId == id).ToList();
            var policyItemsWithMap = _mapper.Map<List<ServicePolicyItemView>>(policyItems);
            return await Result<List<ServicePolicyItemView>>.SuccessAsync(policyItemsWithMap, "List of policy Items");
        }
          
    }
}

using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Application.Wrapper;
using ReservationProject.Domain.Entities.ServicePolicyItem;
using ReservationProject.Infrastructure.DTOs.ServicePolicyItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface IServicePolicyItemService
    {
        // get the policy item with policy id  
        Task<Result<List<ServicePolicyItemView>>> GetItemListbyPolicyId(long id);
        Task<IResult> Create(ServicePolicyItemView input);
        Task<IResult> Edit(long id, ServicePolicyItemView input);

        Task<IResult> Delete(long id);
    }
}

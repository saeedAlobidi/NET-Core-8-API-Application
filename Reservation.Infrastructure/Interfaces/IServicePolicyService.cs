using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.ServicePolicy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface IServicePolicyService
    {
        // get the policy with items
        Task<Result<List<ServicePolicyView>>> GetList();

        // delete policy 
        Task<IResult> Delete(long id);

        // create policy 
        Task<IResult> Create(ServicePolicyView serviceModal);

        // edit policy 
        // Task<IResult> Edit(long id, ServicePolicyView serviceModal);

    }
}

using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.ServiceModal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface IServiceModalService
    {
        Task<Result<List<ServiceModalView>>> GetList(); 
        Task<Result<List<ServiceModalView>>> GetServiceById(long id);
        Task<Result<List<ServiceModalView>>> GetServiceByUserId(string userid); 
        Task<IResult> Create(ServiceModalView serviceModal);
        Task<IResult> Edit(long id ,ServiceModalView serviceModal);
        Task<IResult> ChangeDiscountStatus(long id); 
        Task<IResult> LockService(long id); 
        Task<IResult> Delete(long id);
    }
}

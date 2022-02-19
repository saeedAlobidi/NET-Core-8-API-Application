using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.AvailableServiceTime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface IAvailableServiceTimeService
    { 
        Task<Result<List<AvailableServiceTimeView>>> GetAvailableServiceTimeByAvailableServiceId(long id);

        //Task<IResult> Create(AvailableServiceTimeView availableServiceTime);
        Task<IResult> Edit(long id, AvailableServiceTimeView availableServiceTime); 
        Task<IResult> Delete(long id);
    }
}

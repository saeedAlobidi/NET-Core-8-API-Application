using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.AvailableService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface IAvailableServiceService
    {
        Task<Result<List<AvailableServiceView>>> GetAvailableServiceTimeByAvailableServiceId(long id);
        Task<IResult> Create(AvailableServiceView availableServiceTime);
        Task<IResult> Edit(long id, AvailableServiceView availableServiceTime);
        Task<IResult> Delete(long id);
    }
}

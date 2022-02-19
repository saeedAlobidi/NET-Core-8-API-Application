using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.Location;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface ILocationService
    {
        Task<Result<List<LocationView>>> GetLocationByServiceId(long id);
        Task<IResult> Create(LocationView availableServiceTime);
        Task<IResult> Edit(long id, LocationView availableServiceTime);
        Task<IResult> Delete(long id);
    }
}

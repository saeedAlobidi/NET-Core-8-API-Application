using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface IRateService
    {
        Task<IResult> Create(RateView rateView);
        Task<IResult> Edit(long id, RateView rateView); 
        Task<IResult> Delete(long id);
        Task<Result<List<RateView>>> GetRateAndCommendBySericeId(long id);
    }
}

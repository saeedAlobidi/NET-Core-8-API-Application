using ReservationProject.Application.Wrapper;
using ReservationProject.Infrastructure.DTOs.TemporaryReservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Interfaces
{
    public interface ITemporaryReservationService
    {
        Task<Result<List<TemporaryReservationView>>> GetAllTemporaryReservation();

        Task<Result<List<TemporaryReservationView>>> GetTemporaryReservationByUserId(string id);
        Task<Result<List<TemporaryReservationView>>> GetTemporaryReservationById(long id);
        Task<IResult> Create(TemporaryReservationView temporaryReservation);

        Task<IResult> Delete(long id);
    }
}

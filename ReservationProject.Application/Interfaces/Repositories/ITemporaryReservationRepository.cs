using ReservationProject.Domain.Entities.TemporaryReservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Application.Interfaces.Repositories
{
    public interface ITemporaryReservationRepository  : IRepositoryAsync<TemporaryReservation>
    {
    }
}

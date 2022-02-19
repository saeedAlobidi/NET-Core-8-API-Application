using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.TemporaryReservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.Repositories
{
    public class TemporaryReservationRepository : RepositoryAsync<TemporaryReservation>, ITemporaryReservationRepository
    {
        public TemporaryReservationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

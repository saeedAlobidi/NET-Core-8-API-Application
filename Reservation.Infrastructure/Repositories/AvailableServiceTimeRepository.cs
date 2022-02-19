using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.AvailableServiceTime;
using ReservationProject.Infrastructure.Interfaces;

namespace ReservationProject.Infrastructure.Repositories
{
    public class AvailableServiceTimeRepository : RepositoryAsync<AvailableServiceTime>, IAvailableServiceTimeRepository
    {
        public AvailableServiceTimeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

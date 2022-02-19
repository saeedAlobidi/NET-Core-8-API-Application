using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.Rate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.Repositories
{
    public class RateRepository : RepositoryAsync<Rate>, IRateRepository
    {
        public RateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

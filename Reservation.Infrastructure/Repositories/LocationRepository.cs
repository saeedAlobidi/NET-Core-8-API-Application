using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.Repositories
{
    public class LocationRepository : RepositoryAsync<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

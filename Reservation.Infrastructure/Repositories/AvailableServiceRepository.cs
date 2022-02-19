using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.AvailableService;
using ReservationProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.Repositories
{
    
    public class AvailableServiceRepository : RepositoryAsync<AvailableService>, IAvailableServiceRepository
    {
        public AvailableServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

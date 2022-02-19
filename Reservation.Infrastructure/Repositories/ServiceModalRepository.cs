
using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.ServiceModal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.Repositories
{
    public class ServiceModalRepository : RepositoryAsync<ServiceModal>, IServiceModalRepository
    {
        public ServiceModalRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
    }
}

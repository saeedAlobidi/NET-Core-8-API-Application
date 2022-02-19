using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.ServicePolicy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.Repositories
{
   
    public class ServicePolicyRepository : RepositoryAsync<ServicePolicy>, IServicePolicyRepository
    {
        public ServicePolicyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

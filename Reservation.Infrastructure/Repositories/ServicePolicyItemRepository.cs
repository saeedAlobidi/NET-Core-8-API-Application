using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.ServicePolicyItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.Repositories
{
    class ServicePolicyItemRepository : RepositoryAsync<ServicePolicyItem>, IServicePolicyItemRepository
    {
        public ServicePolicyItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

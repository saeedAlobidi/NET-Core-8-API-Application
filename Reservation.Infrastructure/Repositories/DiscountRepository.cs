using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.Discount;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Infrastructure.Repositories
{
    
    public class DiscountRepository : RepositoryAsync<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

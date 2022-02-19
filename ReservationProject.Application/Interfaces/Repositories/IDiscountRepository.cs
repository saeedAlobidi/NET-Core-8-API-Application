using ReservationProject.Domain.Entities.Discount;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationProject.Application.Interfaces.Repositories
{
    public interface IDiscountRepository : IRepositoryAsync<Discount>
    {
    }
}

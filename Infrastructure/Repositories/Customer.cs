using Application.Interfaces.Repositories;
using Infrastructure.DbContexts;
 
 
namespace Infrastructure.Repositories
{
    public   class Customer : Infrastructure.Repositories.GenericRepository<Domain.Entities.Customer.Customer>, Application.Interfaces.Repositories.ICustomer
    {
        public Customer(SystemDbContext ctx) : base(ctx)
        {

        }

        
    }
}

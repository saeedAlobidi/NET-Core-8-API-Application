using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class Test : Itest
    {
        public IQueryable<Domain.Entities.Customer.Customer> GetQueryable => throw new NotImplementedException();

        public Task<Domain.Entities.Customer.Customer> AddAsync(Domain.Entities.Customer.Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Domain.Entities.Customer.Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Customer.Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Customer.Customer>> Getpagining(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Entities.Customer.Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

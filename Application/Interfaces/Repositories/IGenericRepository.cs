using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetQueryable { get; }

        Task<List<T>> GetAllAsync();

        Task<List<T>> Getpagining(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
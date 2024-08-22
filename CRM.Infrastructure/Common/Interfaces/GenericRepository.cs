using System.Linq;
using System.Linq.Expressions;
using CRM.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CRM.Infrastructure.Common.Interfaces
{
    public class GenericRepository<T> where T : class
    {
        private readonly CRMManagementDbContext _ctx;

        public GenericRepository(CRMManagementDbContext ctx)
        {
            this._ctx = ctx;
        }

        public IQueryable<T> GetQueryable => this._ctx.Set<T>().AsNoTracking();

        public async Task<T> AddAsync(T entity, CancellationToken token = default)
        {
            await this._ctx.Set<T>().AddAsync(entity, token);
            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken token = default)
        {
            await Task.Run(() => this._ctx.Set<T>().Remove(entity), token);

        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken token = default)
        {
            var entities = await this._ctx.Set<T>().Where(predicate).ToListAsync(token);

            if (entities.Any())
            {
                await Task.Run(() => this._ctx.Set<T>().RemoveRange(entities), token);
            }
        }

        public async Task UpdateAsync(T entity,CancellationToken token = default)
        {
            await Task.Run(() => this._ctx.Entry(entity).CurrentValues.SetValues(entity), token);

        }

        public async Task<List<TResult>> GetAllAsync<TResult>(
            Expression<Func<T, bool>> predicate,
            Func<T, TResult> selector,
            CancellationToken token = default)
        {
            return await this.GetQueryable
                .Where(predicate)
                .Select(a => selector(a))
                .ToListAsync(token);
        }

        public async Task<TResult> GetOneAsync<TResult>(
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, TResult>> selector,
            CancellationToken token = default)
        {
            return await GetQueryable
                .Where(predicate)
                .Select(selector)
                .FirstOrDefaultAsync(token);
        }
    }
}

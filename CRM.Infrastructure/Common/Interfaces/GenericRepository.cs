


using System.Linq;
using System.Linq.Expressions;
using CRM.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Common.Interfaces;

public class GenericRepository<T> where T : class
{
    private CRMManagementDbContext _ctx;

    public GenericRepository(CRMManagementDbContext ctx)
    {
        this._ctx = ctx;
    }

    public IQueryable<T> GetQueryable => this._ctx.Set<T>().AsNoTracking();

    public async Task<T> AddAsync(T entity)
    {
        await this._ctx.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        this._ctx.Set<T>().Remove(entity);

    }

    public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
    {
        var entities = await this._ctx.Set<T>().Where(predicate).ToListAsync();

        if (entities.Any())
        {
            this._ctx.Set<T>().RemoveRange(entities);
        }

    }
    public async Task UpdateAsync(T entity)
    {
        this._ctx.Entry(entity).CurrentValues.SetValues(entity);

    }

    public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, bool>> predicate, Func<T, TResult> selector)
    {

        return await this.GetQueryable.Where(predicate).Select(a => selector(a)).ToListAsync();

    }

 


    public async Task<TResult> GetOneAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
    {
        return await GetQueryable.Where(predicate).Select(selector).FirstOrDefaultAsync();

    } 


}
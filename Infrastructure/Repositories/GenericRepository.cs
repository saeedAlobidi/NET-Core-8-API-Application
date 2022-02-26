using Application.DbContext;
using Application.Interfaces.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private SystemDbContext ctx;

        public GenericRepository(SystemDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetQueryable => this.ctx.Set<T>().AsNoTracking();

        public async Task<T> AddAsync(T entity)
        {
            await this.ctx.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            this.ctx.Set<T>().Remove(entity);
            
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.ctx
                   .Set<T>()
                   .ToListAsync();
        }

        public async Task<List<T>> Getpagining(int pageNumber, int pageSize)
        {
            return await this.ctx
              .Set<T>()
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .AsNoTracking()
              .ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.ctx.Entry(entity).CurrentValues.SetValues(entity);
             
        }
    }
}

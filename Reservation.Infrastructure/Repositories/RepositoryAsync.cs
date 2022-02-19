using Microsoft.EntityFrameworkCore;
using Reservation.Infrastructure.DBContext;
using ReservationProject.Application.Interfaces.Repositories;
using ReservationProject.Domain.Entities.TemporaryReservation;
using ReservationProject.Infrastructure.DTOs.TemporaryReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.Infrastructure.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public IQueryable<T> Entities => _dbContext.Set<T>();
        public IQueryable<T> Entities => _dbContext.Set<T>().AsNoTracking();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        
        public async Task<List<T>> GetAllAsync()
        {
            return  await _dbContext
                .Set<T>()
                .ToListAsync(); 
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }
    }
}

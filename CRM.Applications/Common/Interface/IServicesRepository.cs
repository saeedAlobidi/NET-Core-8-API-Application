



 
using CRM.Domain.Services;

namespace CRM.Services.Common.Interface;

public interface IServicesRepository{
    Task<Service> GetOneAsync(int Id);
    Task AddAsync(Service entity);
    Task DeleteAsync(int Id);
    Task UpdateAsync(Service entity);
}

 
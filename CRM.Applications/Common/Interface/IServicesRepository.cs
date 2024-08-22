



 
using CRM.Domain.Services;

namespace CRM.Services.Common.Interface;

public interface IServicesRepository{
    Task<Service> GetOneAsync(int Id,CancellationToken token);
    Task AddAsync(Service entity,CancellationToken token);
    Task DeleteAsync(int Id,CancellationToken token);
    Task UpdateAsync(Service entity,CancellationToken token);
}

 
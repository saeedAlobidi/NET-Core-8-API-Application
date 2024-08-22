
using CRM.Domain.Services;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.Common.Interfaces;
using CRM.Services.Common.Interface;

namespace CRM.Infrastructure.Persistence;

public class ServicesRepository : IServicesRepository
{


    GenericRepository<Service> _genericRepository; // l prefer Composition to Inheritance ^_*
    public ServicesRepository(GenericRepository<Service> genericRepository )
    {
       
        _genericRepository = genericRepository;
    }


    public async Task AddAsync(Service Service,CancellationToken token)
    {
        await _genericRepository.AddAsync(Service,token);
    }


    public async Task DeleteAsync(int Id,CancellationToken token)
    {
        await _genericRepository.DeleteAsync(lead => lead.Id == Id,token);
    }



    public async Task<Service> GetOneAsync(int Id,CancellationToken token)
    {
        return await _genericRepository.GetOneAsync(Service => Service.Id == Id, sv_project => sv_project,token);
    }

    public async Task UpdateAsync(Service entity,CancellationToken token)
    {
        await _genericRepository.UpdateAsync(entity,token);
    }
}
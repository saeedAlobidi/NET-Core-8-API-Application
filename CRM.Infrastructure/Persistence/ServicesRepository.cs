
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


    public async Task AddAsync(Service Service)
    {
        await _genericRepository.AddAsync(Service);
    }


    public async Task DeleteAsync(int Id)
    {
        await _genericRepository.DeleteAsync(lead => lead.Id == Id);
    }



    public async Task<Service> GetOneAsync(int Id)
    {
        return await _genericRepository.GetOneAsync(Service => Service.Id == Id, sv_project => sv_project);
    }

    public async Task UpdateAsync(Service entity)
    {
        await _genericRepository.UpdateAsync(entity);
    }
}
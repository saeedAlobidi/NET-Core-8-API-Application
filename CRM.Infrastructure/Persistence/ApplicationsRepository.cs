
using CRM.Domain.Applications;
using CRM.Applications.Common.Interface;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.Common.Interfaces;

namespace CRM.Infrastructure.Persistence;

public class ApplicationRepository : IApplicationsRepository
{


    GenericRepository<Application> _genericRepository; // l prefer Composition to Inheritance ^_* 
    public ApplicationRepository(GenericRepository<Application> genericRepository)
    {

        _genericRepository = genericRepository;
    }


    public async Task AddAsync(Application Application)
    {
        await _genericRepository.AddAsync(Application);
    }


    public async Task DeleteAsync(int Id)
    {
        await _genericRepository.DeleteAsync(app => app.Id == Id);
    }



    public async Task<Application> GetOneAsync(int Id)
    {
        return await _genericRepository.GetOneAsync(Application => Application.Id == Id, ap_project => ap_project);
    }

    public async Task UpdateAsync(Application entity)
    {
        await _genericRepository.UpdateAsync(entity);
    }
}
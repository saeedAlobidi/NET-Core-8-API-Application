
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


    public async Task AddAsync(Application Application,CancellationToken token)
    {
        await _genericRepository.AddAsync(Application,token);
    }


    public async Task DeleteAsync(int Id,CancellationToken token)
    {
        await _genericRepository.DeleteAsync(app => app.Id == Id,token);
    }



    public async Task<Application> GetOneAsync(int Id,CancellationToken token)
    {
        return await _genericRepository.GetOneAsync(Application => Application.Id == Id, ap_project => ap_project,token);
    }

    public async Task UpdateAsync(Application entity,CancellationToken token)
    {
        await _genericRepository.UpdateAsync(entity,token);
    }
}
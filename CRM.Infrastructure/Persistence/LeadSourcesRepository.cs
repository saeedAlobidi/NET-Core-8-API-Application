
using CRM.Domain.Leads;
using CRM.Applications.Common.Interface;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CRM.Infrastructure.Persistence;

public class LeadSourcesRepository : ILeadSourcesRepository
{
    GenericRepository<LeadSource> _genericRepository; // l prefer Composition to Inheritance ^_*

    public LeadSourcesRepository(GenericRepository<LeadSource> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task AddAsync(LeadSource entity, CancellationToken token)
    {
        await _genericRepository.AddAsync(entity, token);
    }




    public Task<LeadSource> GetOneAsync(int Id, CancellationToken token)
    {
        return _genericRepository.GetOneAsyncForUpdate<LeadSource>(c => c.Id == Id, leadSource => leadSource, token);
    }

    public Task UpdateAsync(LeadSource entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
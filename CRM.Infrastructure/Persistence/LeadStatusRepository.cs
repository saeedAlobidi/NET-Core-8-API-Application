
using CRM.Domain.Leads;
using CRM.Applications.Common.Interface;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CRM.Infrastructure.Persistence;

public class LeadStatusRepository : ILeadStatusRepository
{
    GenericRepository<LeadStatus> _genericRepository; // l prefer Composition to Inheritance ^_*

    public LeadStatusRepository(GenericRepository<LeadStatus> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task AddAsync(LeadStatus entity, CancellationToken token)
    {
        await _genericRepository.AddAsync(entity, token);
    }




    public Task<LeadStatus> GetOneAsync(int Id, CancellationToken token)
    {
        return _genericRepository.GetOneAsyncForUpdate<LeadStatus>(c => c.Id == Id, LeadStatus => LeadStatus, token);
    }

    public Task UpdateAsync(LeadStatus entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
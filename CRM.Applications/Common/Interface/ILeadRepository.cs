



using CRM.Domain.Leads;

namespace CRM.Applications.Common.Interface;

public interface ILeadRepository
{
    Task<Lead> GetOneAsync(int Id, CancellationToken token);
    Task AddAsync(Lead entity, CancellationToken token);
    Task DeleteAsync(int Id, CancellationToken token);
    Task DeleteAsync(Lead Lead, CancellationToken token);

    Task UpdateAsync(Lead entity, CancellationToken token);

}

public interface ILeadSourcesRepository
{
    Task<LeadSource> GetOneAsync(int Id, CancellationToken token);
    Task AddAsync(LeadSource entity, CancellationToken token);

    Task UpdateAsync(LeadSource entity, CancellationToken token);

}

public interface ILeadStatusRepository
{
    Task<LeadStatus> GetOneAsync(int Id, CancellationToken token);
    Task AddAsync(LeadStatus entity, CancellationToken token);

    Task UpdateAsync(LeadStatus entity, CancellationToken token);

}


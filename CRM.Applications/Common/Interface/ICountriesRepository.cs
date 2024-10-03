





using CRM.Domain.Applications;
using CRM.Domain.Leads;

public interface ICountriesRepository
{
    Task<Countries> AddAsync(Countries entity, CancellationToken token);
    Task<Countries> getAsync(string countryCode, CancellationToken token);

    Task DeleteAsync(int Id, CancellationToken token);
    Task UpdateAsync(Countries entity, CancellationToken token);
}


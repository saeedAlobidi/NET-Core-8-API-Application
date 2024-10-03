
using CRM.Domain.Leads;
using CRM.Applications.Common.Interface;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CRM.Infrastructure.Persistence;

public class CountriesRepository : ICountriesRepository
{
    GenericRepository<Countries> _genericRepository; // l prefer Composition to Inheritance ^_*

    public CountriesRepository(GenericRepository<Countries> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Countries> getAsync(string countryCode, CancellationToken token)
    {
        return await _genericRepository.GetOneAsyncForUpdate<Countries>(c => c.CountryCode == countryCode, country => country, token);
       
    }
    public async Task<Countries> AddAsync(Countries entity, CancellationToken token)
    {
        var data = await _genericRepository.AddAsync(entity, token);
        return data;

    }

    public Task DeleteAsync(int Id, CancellationToken token)
    {
        throw new NotImplementedException();
    }



    public Task UpdateAsync(Countries entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
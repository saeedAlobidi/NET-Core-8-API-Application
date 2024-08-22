
using CRM.Domain.Leads;
using CRM.Applications.Common.Interface;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CRM.Infrastructure.Persistence;

public class LeadRepository : ILeadRepository
{
     GenericRepository<Lead> _genericRepository; // l prefer Composition to Inheritance ^_*
    
    public LeadRepository(GenericRepository<Lead> genericRepository)
    {  
        _genericRepository = genericRepository;
    }


    public async Task AddAsync(Lead lead,CancellationToken token)
    {


        await _genericRepository.AddAsync(lead,token);
    }


    public async Task DeleteAsync(int Id,CancellationToken token)
    {

        await _genericRepository.DeleteAsync(lead => lead.Id == Id,token);
    }

    public async Task DeleteAsync(Lead Lead,CancellationToken token)
    {
        await _genericRepository.DeleteAsync(Lead,token);
     }
   

    public async Task<Lead> GetOneAsync(int Id,CancellationToken token)
    {

      return await _genericRepository.GetOneAsync<Lead>(lead => lead.Id == Id, lead_project => lead_project,token);
        
    }

    public async Task UpdateAsync(Lead entity,CancellationToken token)
    {
        await _genericRepository.UpdateAsync(entity,token);
    }
}
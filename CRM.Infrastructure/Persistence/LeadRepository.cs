
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


    public async Task AddAsync(Lead lead)
    {


        await _genericRepository.AddAsync(lead);
    }


    public async Task DeleteAsync(int Id)
    {

        await _genericRepository.DeleteAsync(lead => lead.Id == Id);
    }

    public async Task DeleteAsync(Lead Lead)
    {
        await _genericRepository.DeleteAsync(Lead);
     }
   

    public async Task<Lead> GetOneAsync(int Id)
    {

      return await _genericRepository.GetOneAsync<Lead>(lead => lead.Id == Id, lead_project => lead_project);
        
    }

    public async Task UpdateAsync(Lead entity)
    {
        await _genericRepository.UpdateAsync(entity);
    }
}
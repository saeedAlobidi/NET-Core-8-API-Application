



using CRM.Domain.Leads;

namespace CRM.Applications.Common.Interface;

public interface ILeadRepository{
    Task<Lead> GetOneAsync(int Id);
    Task AddAsync(Lead entity);
    Task DeleteAsync(int Id);
     Task DeleteAsync(Lead Lead);

    Task UpdateAsync(Lead entity);
    
}

 
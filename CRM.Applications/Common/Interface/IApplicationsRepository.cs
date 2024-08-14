





using CRM.Domain.Applications;

public interface IApplicationsRepository{
    Task<Application> GetOneAsync(int Id);
    Task AddAsync(Application entity);
    Task DeleteAsync(int Id);
    Task UpdateAsync(Application entity);
}

 
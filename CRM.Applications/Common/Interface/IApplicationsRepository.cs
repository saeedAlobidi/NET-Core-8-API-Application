





using CRM.Domain.Applications;

public interface IApplicationsRepository{
    Task<Application> GetOneAsync(int Id,CancellationToken token);
    Task AddAsync(Application entity,CancellationToken token);
    Task DeleteAsync(int Id,CancellationToken token);
    Task UpdateAsync(Application entity,CancellationToken token);
}

 
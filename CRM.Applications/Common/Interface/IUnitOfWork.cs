namespace CRM.Applications.Common.Interface;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}
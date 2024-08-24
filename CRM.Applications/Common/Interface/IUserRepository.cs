



using CRM.Domain.Users;
using ErrorOr;

namespace CRM.Applications.Common.Interface;

public interface IUserRepository
{
    Task<Object> GetOneAsync(string userName, CancellationToken token);
    Task<ErrorOr<string>> Login(string userName, string password, CancellationToken token);
    Task<ErrorOr<Success>> AddAsync(User entity, CancellationToken token);
    Task<ErrorOr<Success>> changePassword(User entity, string currentPassword, string password, CancellationToken token);
    Task<ErrorOr<Object>> addRole(string roleName, CancellationToken token);

    Task<ErrorOr<Object>> getRole(string roleName, CancellationToken token);

    Task<ErrorOr<Success>> addRoleToUser(Object user, string roleName, CancellationToken token);
    Task<ErrorOr<Success>> GetUsersInRole(string roleName, CancellationToken token);
    Task<ErrorOr<Success>> addPermissionToRole(Object role, List<string> permissionName, CancellationToken token);


}


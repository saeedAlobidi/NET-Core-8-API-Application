
using CRM.Domain.Users;
using CRM.Applications.Common.Interface;
using CRM.Infrastructure.Common.Persistence;
using CRM.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using CRM.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using CRM.Infrastructure.Common.Extension;
using ErrorOr;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using CRM.Infrastructure.Utilities;

namespace CRM.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly GenericRepository<string> _genericRepository; // l prefer Composition to Inheritance ^_*

    private readonly UserManager<SystemUser> _userManager;
    private readonly RoleManager<SystemRole> _roleManager;

    private readonly IConfiguration _configuration;
    private readonly JwtToken _jwtToken;

    public UserRepository(GenericRepository<string> genericRepository, UserManager<SystemUser> userManager, RoleManager<SystemRole> roleManager, IConfiguration configuration, JwtToken jwtToken)
    {
        _genericRepository = genericRepository;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _jwtToken = jwtToken;
    }


    public async Task<ErrorOr<Success>> AddAsync(User user, CancellationToken token)
    {

        var result = await _userManager.CreateAsync(user.MapToSystemUser(), user.PasswordHash);
        return result.Succeeded
               ? Result.Success
               : result.Errors.Select(error => Error.Validation(code: error.Code, description: error.Description)).ToList();


    }



    public async Task<ErrorOr<Object>> addRole(string roleName, CancellationToken token)
    {
        var role = new SystemRole(roleName);
        var result = await _roleManager.CreateAsync(role);
        return result.Succeeded
                      ? role
                      : result.Errors.Select(error => Error.Validation(code: error.Code, description: error.Description)).ToList();


    }

    public async Task<ErrorOr<Success>> addPermissionToRole(Object role, List<string> permissionName, CancellationToken token)
    {
        var result = permissionName.Select((async (a) => await _roleManager.AddClaimAsync((SystemRole)role, new Claim("Permission", a)))).ToList();

        return result.FirstOrDefault().Result.Succeeded
                      ? Result.Success
                      : result.FirstOrDefault().Result.Errors.Select(error => Error.Validation(code: error.Code, description: error.Description)).ToList();


    }

    public async Task<ErrorOr<Success>> addRoleToUser(Object user, string roleName, CancellationToken token)
    {
        var result = await _userManager.AddToRoleAsync((SystemUser)user, roleName);
        return result.Succeeded
                             ? Result.Success
                             : result.Errors.Select(error => Error.Validation(code: error.Code, description: error.Description)).ToList();

    }

    public async Task<ErrorOr<Success>> changePassword(User entity, string currentPassword, string password, CancellationToken token)
    {
        var result = await _userManager.ChangePasswordAsync(entity.MapToSystemUser(), currentPassword, password);
        return result.Succeeded
                       ? Result.Success
                       : result.Errors.Select(error => Error.Validation(code: error.Code, description: error.Description)).ToList();


    }

    public async Task<Object> GetOneAsync(string userName, CancellationToken token)
    {
        return await _userManager.FindByNameAsync(userName);


    }

    public async Task<ErrorOr<Object>> getRole(string roleName, CancellationToken token)
    {
        var role = await _roleManager.FindByNameAsync(roleName);

        return (role != null) ? role : Error.NotFound(description: "no user find");

    }

    public Task<ErrorOr<Success>> GetUsersInRole(string roleName, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<string>> Login(string userName, string password, CancellationToken token)
    {

        var user = await _userManager.FindByEmailAsync(userName);
        var validUser=await _userManager.CheckPasswordAsync(user, password);
        return (user != null && validUser ) ?

              await _jwtToken.GenerateToken(user) : Error.Validation(code: "404", description: "no user find");


    }




}
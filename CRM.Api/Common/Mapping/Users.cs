using CRM.Api.Controllers.Contracts;

using CRM.Domain.Users;
using CRM.Users.Commands.CreateUser;

namespace CRM.Api.Controllers.Common.Mapping;

public static class Users
{


    public static CreateUserCommand MapToUsersCommand(this CreateUserRequest request)
    {
        return new CreateUserCommand(UserName: request.UserName, Email: request.Name,PasswordHash:request.PasswordHash, Linkedin: request.linkedin);

    }

    
    public static CreateUserResponse MapToResponse(this User user)
    {
        return new CreateUserResponse(Id: user.Id,  UserName: user.UserName, Name: user.Name,linkedin: user.linkedin);

    }

 
}
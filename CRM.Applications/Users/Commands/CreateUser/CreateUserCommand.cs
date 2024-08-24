
using CRM.Domain.Users;
using ErrorOr;
using MediatR;

namespace CRM.Users.Commands.CreateUser;

public record CreateUserCommand(string UserName,string Email,string PasswordHash,string Linkedin):IRequest<ErrorOr<User>>;


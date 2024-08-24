
using ErrorOr;
using MediatR;

namespace CRM.Applications.Users.Commands.AssignUserToRole;

public record AssignUserToRoleCommand(string roleName, string username):IRequest<ErrorOr<Success>>;


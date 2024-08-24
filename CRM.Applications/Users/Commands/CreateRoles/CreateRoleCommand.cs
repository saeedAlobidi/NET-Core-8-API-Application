
using ErrorOr;
using MediatR;

namespace CRM.Users.Commands.CreateRole;

public record CreateRoleCommand(string RoleName, List<string>Permission):IRequest<ErrorOr<Success>>;


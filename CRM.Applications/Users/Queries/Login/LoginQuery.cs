using CRM.Domain.Users;
using ErrorOr;
using MediatR;

namespace CRM.Users.Queries.Login;

public record LoginQuery(string userName,string password) : IRequest<ErrorOr<string>>;

using ErrorOr;
using MediatR;

namespace CRM.Services.Commands.CreateServices;

public record CreateServicesCommand(string Name,decimal Price):IRequest<ErrorOr<Domain.Services.Service>>;



using ErrorOr;
using MediatR;

namespace CRM.Applications.Commands.CreateApplications;

public record CreateApplicationsCommand(string Name,int LeadId,int ServiceId):IRequest<ErrorOr<Domain.Applications.Application>>;


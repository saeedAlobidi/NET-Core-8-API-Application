
using CRM.Domain.Leads;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.CreateLeadSource;

public record CreateLeadSourceCommand(int id,string Name):IRequest<ErrorOr<LeadSource>>;


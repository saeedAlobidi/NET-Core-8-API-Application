
using CRM.Domain.Leads;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.CreateLeadSource;

public record CreateLeadStatusCommand(int id,string Name):IRequest<ErrorOr<LeadStatus>>;


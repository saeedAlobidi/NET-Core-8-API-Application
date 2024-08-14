using CRM.Domain.Leads;
using ErrorOr;
using MediatR;

namespace CRM.Leads.Queries.GetLeads;

public record GetLeadQuery(int LeadId) : IRequest<ErrorOr<Lead>>;
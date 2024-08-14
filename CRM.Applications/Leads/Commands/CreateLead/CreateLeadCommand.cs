
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.CreateLead;

public record CreateLeadCommand(string Name,int Age,string Email,string Linkedin):IRequest<ErrorOr<Domain.Leads.Lead>>;


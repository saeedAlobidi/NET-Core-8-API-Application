
using ErrorOr;
using MediatR;

namespace CRM.Leads.Commands.DeleteLead;


public record DeleteLeadCommand(int id):IRequest<ErrorOr<Success>>;

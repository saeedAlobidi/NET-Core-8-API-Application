using CRM.Domain.Leads;
using CRM.Domain.Services;

namespace CRM.Api.Controllers.Contracts;

public record CreateApplicationRequest(string Name,int LeadId,int ServicesId);
public record CreateApplicationResponse(int Id,string Name, Domain.Leads.Lead Lead, Domain.Services.Service Services);

 
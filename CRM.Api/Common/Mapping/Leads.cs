using CRM.Api.Controllers.Contracts;

using CRM.Domain.Leads;
using CRM.Leads.Commands.CreateLead;

namespace CRM.Api.Controllers.Common.Mapping;

public static class Leads
{


    public static CreateLeadCommand MapToLeadsCommand(this CreateLeadRequest request)
    {
        return new CreateLeadCommand(Age: request.Age, Name: request.Name, Email: request.Email, Linkedin: request.Linkedin);

    }

    
    // public static CreateLeadResponse MapToResponse(this Lead lead)
    // {
    //     return new CreateLeadResponse(Id: lead.Id, Age: lead.age, Name: lead.name, Email: lead.email, Linkedin: lead.linkedin);

    // }

 
}
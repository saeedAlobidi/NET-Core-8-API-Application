using CRM.Api.Controllers.Contracts;
using CRM.Applications.Commands.CreateApplications;

namespace CRM.Api.Controllers.Common.Mapping;

public static class Applications
{


    public static CreateApplicationsCommand MapToApplicationsCommand(this CreateApplicationRequest request)
    {
        return new CreateApplicationsCommand( Name:request.Name,LeadId: request.LeadId, ServiceId: request.ServicesId);

    }

    
    public static CreateApplicationResponse MapToResponse(this CRM.Domain.Applications.Application application)
    {
        return new CreateApplicationResponse(Id:application.Id,Name:application.name,Lead: application.lead, Services: application.service);

    }


}
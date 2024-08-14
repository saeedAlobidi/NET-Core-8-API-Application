using CRM.Api.Controllers.Contracts;
 using CRM.Domain.Services;
using CRM.Services.Commands.CreateServices;


namespace CRM.Api.Controllers.Common.Mapping;

public static class Services
{


    public static CreateServicesCommand MapToServicessCommand(this CreateServiceRequest request)
    {
        return new CreateServicesCommand( Name: request.Name, Price: request.Price);

    }

    
    public static CreateServiceResponse MapToResponse(this Service services)
    {
        return new CreateServiceResponse(Id: services.Id, Name: services.name, Price: services.price);

    }


}
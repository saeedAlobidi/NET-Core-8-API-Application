namespace CRM.Api.Controllers.Contracts;

public record CreateServiceRequest(string Name,Decimal Price);
public record CreateServiceResponse(int Id,string Name,Decimal Price);

 
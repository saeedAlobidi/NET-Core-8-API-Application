namespace CRM.Api.Controllers.Contracts;

public record CreateLeadRequest(int Id, int Age, string Name, string Email, string Linkedin);

public record CreateLeadResponse(int Id, int Age, string Name, string Email, string Linkedin);

public record GetLeadByIdRequest(int Id);


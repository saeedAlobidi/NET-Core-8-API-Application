namespace CRM.Api.Controllers.Contracts;

public record CreateUserRequest(string UserName, string Name, string PasswordHash,string? linkedin);

public record CreateUserResponse(int Id, string UserName, string Name,string? linkedin);




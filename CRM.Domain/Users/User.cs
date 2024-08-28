using ErrorOr;
using CRM.Domain.Common;
using CRM.Domain.Common.DomainEvent;

namespace CRM.Domain.Users;

//plz dont use Guid is not sufficiant for database
public class User:Entity<int>
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }
    public String? linkedin { get; set; }
    public async Task<ErrorOr<Success>> ValidateAsync()
    {

        var validator = new UserValidator();
        var validatorResult = await validator.ValidateAsync(this);

        if (!validatorResult.IsValid)
            return validatorResult.Errors.Select(error => Error.Validation(code: error.PropertyName, description: error.ErrorMessage))
            .ToList();
        return Result.Success;

    }



}



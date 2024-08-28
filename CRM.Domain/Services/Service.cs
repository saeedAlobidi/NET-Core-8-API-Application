using ErrorOr;
using CRM.Domain.Common;



namespace CRM.Domain.Services;


//plz dont use Guid is not sufficiant for database

public class Service : Entity<int>
{

     
 
    public String name { get; set; }
    public Decimal  price { get; set; }
   


    public async Task<ErrorOr<Success>> ValidateAsync()
    {

        var validator = new ServiceValidator();
        var validatorResult = await validator.ValidateAsync(this);

        if (!validatorResult.IsValid)
            return validatorResult.Errors.Select(error => Error.Validation(code: error.PropertyName, description: error.ErrorMessage))
            .ToList();
        return Result.Success;

    }
     

}



using ErrorOr;
using CRM.Domain.Common;
using CRM.Domain.Leads;
using CRM.Domain.Services;


namespace CRM.Domain.Applications;


//plz dont use Guid is not sufficiant for database
public class Application : Aggregation<int>
{


    public string name { get; set; }
    public Lead lead { get; set; }
    public Service service { get; set; }
    public bool isDeleted = false;





    public async Task<ErrorOr<Success>> ValidateAsync(Lead lead, Service service, string name)
    {


        this.name = name;
        this.lead = lead;
        this.service = service;
        var validator = new ApplicationValidator();
        var validatorResult = await validator.ValidateAsync(this);

        if (!validatorResult.IsValid)
            return validatorResult.Errors.Select(error => Error.Validation(code: error.PropertyName, description: error.ErrorMessage))
            .ToList();
        return Result.Success;

    }

    public ErrorOr<Success> deleteApplication()
    {
        this.isDeleted = true;
        return Result.Success;

    }
}



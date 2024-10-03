using ErrorOr;
using CRM.Domain.Common;
using CRM.Domain.Common.DomainEvent;
using System.Runtime.CompilerServices;

namespace CRM.Domain.Leads;

//plz dont use Guid is not sufficiant for database
public class Lead : Aggregation<int>
{


    /*Lead Information*/
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public LeadSource LeadSource { get; set; }
    public LeadStatus Status { get; set; }

    /* Address Information */
    public Countries Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }

    /* Description Information */
    public string Description { get; set; }

    public async Task<ErrorOr<Success>> ValidateAsync()
    {

        var validator = new LeadValidator();
        var validatorResult = await validator.ValidateAsync(this);

        if (!validatorResult.IsValid)
            return validatorResult.Errors.Select(error => Error.Validation(code: error.PropertyName, description: error.ErrorMessage))
            .ToList();
        return Result.Success;

    }

    
}




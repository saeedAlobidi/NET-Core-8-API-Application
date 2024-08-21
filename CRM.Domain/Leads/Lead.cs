using ErrorOr;
using CRM.Domain.Common;
using CRM.Domain.Common.DomainEvent;

namespace CRM.Domain.Leads;

//plz dont use Guid is not sufficiant for database
public class Lead : Entity<int>
{

    private readonly int _minimumAge = 18;
    public int age { get; set; }
    public String name { get; set; }
    public String email { get; set; }
    public String linkedin { get; set; }
    public bool isCustomer = false;
    public bool isDeleted = false;

    
    

    public async Task<ErrorOr<Success>> AddLead()
    {

        var validator = new LeadValidator(_minimumAge);
        var validatorResult = await validator.ValidateAsync(this);

        if (!validatorResult.IsValid)
            return validatorResult.Errors.Select(error => Error.Validation(code: error.PropertyName, description: error.ErrorMessage))
            .ToList();
        return Result.Success;

    }

    public ErrorOr<Success> deleteLead()
    {
        this.isDeleted = true;
        _domainEvents.Add(new ApplicationDeleteEvent(this.Id));
        return Result.Success;

    }

}



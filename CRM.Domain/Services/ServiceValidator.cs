using FluentValidation;

namespace CRM.Domain.Services;


public class ServiceValidator : AbstractValidator<Service>
{
    public ServiceValidator()
    {

       

        // Email for Name
        RuleFor(_service => _service.name)
               .NotNull()
            .WithMessage("Name cannot be empty. Please provide a valid Name.");

        // Linkedin for Name
        RuleFor(_service => _service.price)
               .NotNull()
               .GreaterThanOrEqualTo(10)
            .WithMessage("Price cannot be less than 10 $. Please provide a valid Price.");
    }
}
using CRM.Domain.Applications;
using FluentValidation;

namespace CRM.Domain.Applications;


public class ApplicationValidator : AbstractValidator<Application>
{
    public ApplicationValidator()
    {

        RuleFor(_application => _application.name)
                      .NotNull()
                   .WithMessage("Name cannot be empty. Please provide a valid Name.");

        // Email for Name
        RuleFor(_application => _application.lead)
               .NotNull()
            .WithMessage("LeadId cannot be null. Please provide a valid LeadId.");

        // Linkedin for Name
        RuleFor(_application => _application.service)
               .NotNull()
            .WithMessage("ServiceId cannot be null. Please provide a valid ServiceId.");
    }
}
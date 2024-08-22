using CRM.Domain.Leads;
using FluentValidation;

namespace CRM.Domain.Leads;


public class LeadValidator : AbstractValidator<Lead>
{
    public LeadValidator(int Age = 0)
    {
        RuleFor(_lead => _lead.age)
         .GreaterThan(Age)
          .LessThan(70)
             .NotNull()
             .WithMessage("Age must be between 18 and 70.");
             
              // Rule for Name
        RuleFor(_lead => _lead.name)
               .NotNull()
             .MinimumLength(3)
             .MaximumLength(30)
            .WithMessage("Name cannot be empty. Please provide a valid name.");
 
        // Email for Name
        RuleFor(_lead => _lead.email)
               .NotNull()
             .EmailAddress()
            .WithMessage(" Please provide a valid Email.");

        // Linkedin for Name
        RuleFor(_lead => _lead.linkedin)
               .NotNull()

            .WithMessage("Linkedin cannot be empty. Please provide a valid Linkedin.");
    }
}
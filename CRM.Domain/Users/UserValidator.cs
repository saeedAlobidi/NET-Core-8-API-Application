using CRM.Domain.Users;
using FluentValidation;

namespace CRM.Domain.Users;


public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {

        // Rule for Name
        RuleFor(_User => _User.Name)
               .NotNull()
             .MinimumLength(3)
             .MaximumLength(30)
            .WithMessage("Name cannot be empty. Please provide a valid name.");

        // Rule for Name
        RuleFor(_User => _User.PasswordHash)
         .NotNull()
       .MinimumLength(5)
       .MaximumLength(30)
      .WithMessage(" Please provide a valid Password. Minimum Length 5 and Maximum Length  30");

        // Email for Name
        RuleFor(_User => _User.UserName)
               .NotNull()
             .EmailAddress()
            .WithMessage(" Please provide a valid UserName.");

        // Linkedin for Name
        RuleFor(_User => _User.linkedin)
               .NotNull()

            .WithMessage("Linkedin cannot be empty. Please provide a valid Linkedin.");
    }
}
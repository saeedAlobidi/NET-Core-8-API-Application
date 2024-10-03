using CRM.Domain.Leads;
using FluentValidation;

namespace CRM.Domain.Leads;


using FluentValidation;

public class LeadValidator : AbstractValidator<Lead>
{
    public LeadValidator()
    {
        // First Name
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .Length(1, 50).WithMessage("First Name must be between 1 and 50 characters.");

        // Last Name
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .Length(1, 50).WithMessage("Last Name must be between 1 and 50 characters.");

        // Title
        RuleFor(x => x.Title)
            .Length(0, 30).WithMessage("Title must be at most 30 characters.");

        // Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email format is invalid.");

        // Phone
        RuleFor(x => x.Phone)
            .Length(0, 15).WithMessage("Phone number must be at most 15 characters.");

        // Mobile
        RuleFor(x => x.Mobile)
            .Length(0, 15).WithMessage("Mobile number must be at most 15 characters.");

        // Country
        RuleFor(x => x.Country)
            .IsInEnum().WithMessage("Country must be a valid enum value.");

        // City
        RuleFor(x => x.City)
            .Length(0, 100).WithMessage("City must be at most 100 characters.");

        // Zip Code
        RuleFor(x => x.ZipCode)
            .Length(0, 20).WithMessage("Zip Code must be at most 20 characters.");

        // Street
        RuleFor(x => x.Street)
            .Length(0, 100).WithMessage("Street must be at most 100 characters.");

        // Description
        RuleFor(x => x.Description)
            .Length(0, 500).WithMessage("Description must be at most 500 characters.");
    }
}

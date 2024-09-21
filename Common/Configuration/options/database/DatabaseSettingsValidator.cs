using FluentValidation;

public class DatabaseSettingsValidator : AbstractValidator<databaseOption>
{
    public DatabaseSettingsValidator()
    {
        RuleFor(x => x.connection)
          .NotEmpty().WithMessage("database connection  is required.");
            
 
    }
}

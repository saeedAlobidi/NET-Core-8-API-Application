using FluentValidation;
using Microsoft.Extensions.Options;

public class FluentValidationOptions<TOption> : IValidateOptions<TOption> where TOption : class
{
    private readonly IValidator<TOption> _validator;

    public FluentValidationOptions(IValidator<TOption> validator)
    {
        _validator = validator;
    }

    public ValidateOptionsResult Validate(string name, TOption options)
    {
        var validationResult = _validator.Validate(options);

        if (validationResult.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        var errors = validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}");
        return ValidateOptionsResult.Fail(errors);
    }
}
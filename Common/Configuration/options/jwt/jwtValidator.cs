using FluentValidation;

public class jwtValidator : AbstractValidator<jwtOption>
{
    public jwtValidator()
    {
        

        RuleFor(x => x.Key)
    .NotEmpty().WithMessage("jwt Key  is required.");

        RuleFor(x => x.Issuer)
           .NotEmpty().WithMessage("jwt Issuer  is required.");

        RuleFor(x => x.Audience)
       .NotEmpty().WithMessage("jwt Audience  is required.");

        RuleFor(x => x.ExpireMinutes)
       .NotEmpty().WithMessage("jwt ExpireMinutes  is required.");

    }
}

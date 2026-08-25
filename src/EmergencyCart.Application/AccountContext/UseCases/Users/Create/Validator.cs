using EmergencyCart.Domain.AccountContext.ValueObjects;
using FluentValidation;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Create;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(y => y.firstName)
            .NotEmpty().WithMessage("......")
            .Matches(Name.Pattern).WithMessage(".....");

        RuleFor(y => y.lastName)
            .NotEmpty().WithMessage("......")
            .Matches(Name.Pattern).WithMessage(".....");

        RuleFor(y => y.email)
            .NotEmpty().WithMessage(".......")
            .Matches(Email.Pattern).WithMessage(".....")
            .Must(IsValidEmail).WithMessage("......................");

        RuleFor(y => y.password)
            .NotEmpty().WithMessage("..........")
            .Matches(Password.Pattern).WithMessage(".....");

    }

    private static bool IsValidEmail(string email)
    {
        var index = email.Split('@')[0];
        return index.Length >= 3;
    }
}

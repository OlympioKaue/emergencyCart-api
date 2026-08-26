using EmergencyCart.Domain.AccountContext.ValueObjects;
using FluentValidation;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Create;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(y => y.firstName)
            .NotEmpty().WithMessage("erro de nome")
            .Matches(Name.Pattern).WithMessage("erro para o nome");

        RuleFor(y => y.lastName)
            .NotEmpty().WithMessage("erro para sobreome")
            .Matches(Name.Pattern).WithMessage("erro para sobreome");

        RuleFor(y => y.email)
            .NotEmpty().WithMessage("erro para email")
            .Matches(Email.Pattern).WithMessage("erro para email")
            .Must(IsValidEmail).WithMessage("erro para email");

        RuleFor(y => y.password)
            .NotEmpty().WithMessage("erro para senha")
            .Matches(Password.Pattern).WithMessage("erro para senha");

    }

    private static bool IsValidEmail(string email)
    {
        var index = email.Split('@')[0];
        return index.Length >= 3;
    }
}

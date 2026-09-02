using EmergencyCart.Domain.AccountContext.ValueObjects;
using FluentValidation;

namespace EmergencyCart.Application.AccountContext.UseCases.Sectors.Create;

public sealed class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(y => y.name)
            .NotEmpty().WithMessage("The name is required.")
            .Matches(Name.Pattern).WithMessage("The name is invalid.")
            .Must(ContainAtLeastTwoWords).WithMessage("The name must contain at least two words (e.g. 'Emergency Room' | 'Medical Clinic').");
    }

    private static bool ContainAtLeastTwoWords(string name)
    {
        var words = name
            .Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return words.Length >= 2;
    }
}

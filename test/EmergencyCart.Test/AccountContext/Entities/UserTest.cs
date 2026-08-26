using EmergencyCart.Application.AccountContext.UseCases.Users.Create;
using EmergencyCart.UniTest.AccountContext;
using FluentValidation.TestHelper;
using Shouldly;

namespace EmergencyCart.Test.AccountContext.Entities;

public class UserTest
{

    #region ShouldReturnSucess
    [Fact]
    public void Create()
    {
        var validate = Validate();
        var command = CommandUser.Build();

        var resultValidation = validate.Validate(command);

        resultValidation.IsValid.ShouldBeTrue();
    }
    #endregion

    [Fact]
    public void ShouldReturnNotEmptyFirstLastName()
    {
        var validate = Validate();
        var command = CommandUser.Build() with { firstName = "", lastName = "" };

        var resultValidation = validate.TestValidate(command);

        resultValidation.ShouldSatisfyAllConditions(
             () => resultValidation.ShouldHaveValidationErrorFor(x => x.firstName)
                  .WithErrorMessage("Fistname cannot be empty"),

            () => resultValidation.ShouldHaveValidationErrorFor(x => x.lastName)
                 .WithErrorMessage("Lastname cannot be empty"));
    }
    [Fact]
    public void ShouldReturnPatternFirstLastName()
    {
        var validate = Validate();
        var command = CommandUser.Build() with { firstName = "Ronaldo2113", lastName = "Da Silva889" };

        var resultValidation = validate.TestValidate(command);

        resultValidation.ShouldSatisfyAllConditions(
             () => resultValidation.ShouldHaveValidationErrorFor(x => x.firstName)
                  .WithErrorMessage("The First Name field must contain only letters and single spaces (no numbers or symbols)"),

            () => resultValidation.ShouldHaveValidationErrorFor(x => x.lastName)
                 .WithErrorMessage("The Last Name field must contain only letters and single spaces (no numbers or symbols)"));
    }


    private Validator Validate()
    {
        return new Validator();
    }
}

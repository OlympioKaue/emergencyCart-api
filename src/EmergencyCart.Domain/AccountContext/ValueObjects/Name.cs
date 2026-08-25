using EmergencyCart.Domain.SharedContext.ValueObjects;
using System.Text.RegularExpressions;

namespace EmergencyCart.Domain.AccountContext.ValueObjects;

public sealed partial record class Name : ValueObject
{
    public const string Pattern = @"^\p{L}+(?: \p{L}+)*$";

    private Name() { }

    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    #region Properties
    public string FirstName { get; } = string.Empty;
    public string LastName { get; } = string.Empty;
    #endregion

    #region Validation
    private static void Validate(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new Exception();

        if(!NameRegex().IsMatch(firstName) || !NameRegex().IsMatch(lastName))
            throw new Exception();
    }
    #endregion

    #region Factory Methods
    public static Name Create(string firstName, string lastName)
    {
        Validate(firstName, lastName);

        return new Name(firstName, lastName);
    }
    #endregion


    [GeneratedRegex(Pattern)]
    public static partial Regex NameRegex();
}

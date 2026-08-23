using EmergencyCart.Domain.SharedContext.ValueObjects;
using System.Text.RegularExpressions;

namespace EmergencyCart.Domain.AccountContext.ValueObjects;

public sealed partial record class Email : ValueObject
{
    public const string Pattern = @"^[a-zA-Z0-9._%+-]{3,}@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    public const int MinLength = 3;

    #region Constructors
    private Email(string email)
    {
        Address = email;
    }
    #endregion

    #region Properties
    public string Address { get; }
    #endregion

    #region Validation
    private static void Validate(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new Exception();

        if (!EmailRegex().IsMatch(email))
            throw new Exception();

        if (email.Split('@')[0].Length < MinLength)
            throw new Exception();
    }
    #endregion

    #region Factory Method
    public static Email Create(string email)
    {
        Validate(email);

       return new Email(email);
    }
    #endregion

    #region Regex Method
    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
    #endregion

}

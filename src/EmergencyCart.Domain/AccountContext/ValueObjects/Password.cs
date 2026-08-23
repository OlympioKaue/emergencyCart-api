using EmergencyCart.Domain.SharedContext.ValueObjects;
using System.Text.RegularExpressions;

namespace EmergencyCart.Domain.AccountContext.ValueObjects;

public sealed partial record class Password : ValueObject
{
    private const string Pattern = "^(?=.*[A-Z])(?=.*[\\W_]).+$";

    private Password(string password)
    {
        Hash = password;
    }

    #region Properties
    public string Hash { get; }
    #endregion

    public static void Validate(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new Exception();

        if (password.Length < 5)
            throw new Exception();

        if (!HashPasswordRegex().IsMatch(password))
            throw new Exception();
    }

    #region Factory Methods
    public static Password Create(string password)
    {
        Validate(password);

        var passwordHash = Encrypt(password);

        return new Password(passwordHash);
    }
    #endregion

    #region Generate Password Hash
    public static string Encrypt(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);
    #endregion

    #region Regex
    [GeneratedRegex(Pattern)]
    private static partial Regex HashPasswordRegex();
    #endregion
}

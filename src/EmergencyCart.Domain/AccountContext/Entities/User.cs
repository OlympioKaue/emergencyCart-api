using EmergencyCart.Domain.AccountContext.Enums;
using EmergencyCart.Domain.AccountContext.ValueObjects;
using EmergencyCart.Domain.SharedContext.AggregateRoots.Abstractions;
using EmergencyCart.Domain.SharedContext.Entities;

namespace EmergencyCart.Domain.AccountContext.Entities;

public sealed class User : Entity, IAggregateRoots
{
    #region // Constructors
    private User() : base(Guid.CreateVersion7()) { }

    private User(Guid id, Name name, Email email, Password password) : base(id)
    {

        Name = name;
        Email = email;
        Password = password;

        IsActive = true;
    }

    #endregion

    #region Properties
    public Name Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    public Role Roles { get; }
    public bool IsActive { get; } = false;

    #endregion

    #region Factory Method
    public static User Create(Name name, Email email, Password password)
    {
        var id = Guid.NewGuid();
        return new User(id, name, email, password);
    }

    public void ChangeNameUpdate(string? firstName, string? lastName)
    {
        var newFirstName = string.IsNullOrWhiteSpace(firstName) ? Name.FirstName : firstName;
        var newLastName = string.IsNullOrWhiteSpace(lastName) ? Name.LastName : lastName;

        Name = Name.Create(newFirstName, newLastName);
    }

    public void ChangeEmailUpdate(string? email)
    {
        var newFirstEmail = string.IsNullOrWhiteSpace(email) ? Email.Address : email;

        Email = Email.Create(newFirstEmail);
    }

    public bool TestePassword(string password)
    => Password.Verify(password, this.Password.Hash);

    public void ChangePasswordEmail(string password)
    {
        Password = Password.Create(password);
    }

    #endregion
}

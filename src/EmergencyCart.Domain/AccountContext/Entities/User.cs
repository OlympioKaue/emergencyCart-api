using EmergencyCart.Domain.AccountContext.Enums;
using EmergencyCart.Domain.AccountContext.ValueObjects;
using EmergencyCart.Domain.SharedContext.AggregateRoots.Abstractions;
using EmergencyCart.Domain.SharedContext.Entities;

namespace EmergencyCart.Domain.AccountContext.Entities;

public sealed class User : Entity, IAggregateRoots
{
    #region // Constructors
    private User(Name name, Email email, Password password) : base(Guid.CreateVersion7())
    {
        Name = name;
        Email = email;
        Password = password;
    }

    #endregion

    #region Properties
    public Name Name { get; }
    public Email Email { get; }
    public Password Password { get; }
    public Role Roles { get; }
    public bool IsActive { get; } = false;

    #endregion

    public static User Create(Name name, Email email, Password password)
    {
        return new User(name, email, password);
    }
}

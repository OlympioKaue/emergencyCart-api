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
    public Name Name { get; } = null!;
    public Email Email { get; } = null!;
    public Password Password { get; } = null!;
    public Role Roles { get; }
    public bool IsActive { get; } = false;

    #endregion

    #region Factory Method
    public static User Create(Name name, Email email, Password password)
    {      
        var id = Guid.NewGuid();
        return new User(id, name, email, password);
    }
    #endregion
}

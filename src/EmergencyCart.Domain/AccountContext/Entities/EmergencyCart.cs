using EmergencyCart.Domain.SharedContext.AggregateRoots.Abstractions;
using EmergencyCart.Domain.SharedContext.Entities;

namespace EmergencyCart.Domain.AccountContext.Entities;

public sealed class EmergencyCart : Entity, IAggregateRoots
{
    private readonly List<CartItem> _cartItems;

    #region Constructors
    private EmergencyCart() : base(Guid.CreateVersion7()) { }

    private EmergencyCart(Guid id, Guid sectorId, string code) : base(id)
    {
        _cartItems = [];
        SectorId = sectorId;
        Code = code;
        IsActive = true;
    }
    #endregion

    #region Properties
    public string Code { get; } = string.Empty;
    public bool IsActive { get; } = false;
    #endregion

    #region Relationships
    public Guid SectorId { get; }
    public Sector Sector { get; } = null!;
    public IReadOnlyCollection<CartItem> CartItems => _cartItems.ToArray();
    #endregion

    public static EmergencyCart Create(Guid sectorId, string code)
    {
        var id = Guid.NewGuid();
        return new EmergencyCart(id, sectorId, code);
    }
}

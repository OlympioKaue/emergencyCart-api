using EmergencyCart.Domain.SharedContext.Entities;

namespace EmergencyCart.Domain.AccountContext.Entities;

public sealed class EmergencyCart : Entity
{
    private readonly List<CartItem> _cartItems;

    #region Constructors
    private EmergencyCart() : base(Guid.CreateVersion7()) { }

    private EmergencyCart(Guid id) : base(id)
    {
        _cartItems = [];
    }
    #endregion

    #region Properties
    public string Code { get; } = string.Empty;
    public string Location { get; } = string.Empty;
    public bool IsActive { get; } = false;
    #endregion

    #region Relationships
    public Guid SectorId { get; }
    public Sector Sector { get; } = null!;
    public IReadOnlyCollection<CartItem> CartItems => _cartItems.ToArray();
    #endregion
}

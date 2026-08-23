using EmergencyCart.Domain.AccountContext.Enums;
using EmergencyCart.Domain.SharedContext.Entities;

namespace EmergencyCart.Domain.AccountContext.Entities;

public sealed class Item : Entity
{
    private readonly List<CartItem> _cartItems;

    #region Constructors
    private Item() : base(Guid.CreateVersion7())
    {
        _cartItems = [];
    }
    #endregion

    #region Properties
    public string Name { get; } = string.Empty;
    public bool IsActive { get; } = false;
    public ItemCategory Category { get; }
    public IReadOnlyCollection<CartItem> CartItems => _cartItems.ToArray();
    #endregion
}

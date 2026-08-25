using EmergencyCart.Domain.SharedContext.Entities;

namespace EmergencyCart.Domain.AccountContext.Entities;

public sealed class CartItem : Entity
{
    #region Constructors
    private CartItem() : base(Guid.CreateVersion7()) { }

    private CartItem(Guid id) : base(id)
    {

    }
    #endregion

    #region Properties
    public int ExpectedQuantity { get; }
    #endregion

    #region Relationships
    public Guid EmergencyCartId { get; }
    public Guid ItemId { get; }
    public EmergencyCart EmergencyCart { get; } = null!;
    public Item Item { get; } = null!;
    #endregion
}

using EmergencyCart.Domain.SharedContext.Entities;

namespace EmergencyCart.Domain.AccountContext.Entities;

public sealed class Sector : Entity
{
    #region List of EmergencyCarts
    private readonly List<EmergencyCart> _emergencyCarts;
    #endregion

    #region Constructors
    private Sector() : base(Guid.CreateVersion7())
    {
        _emergencyCarts = [];
    }
    #endregion

    #region Properties
    public string Name { get; } = string.Empty;
    public bool IsActive { get; } = false;
    #endregion

    #region Relationships
    public IReadOnlyCollection<EmergencyCart> EmergencyCarts => _emergencyCarts.ToArray();
    #endregion
}

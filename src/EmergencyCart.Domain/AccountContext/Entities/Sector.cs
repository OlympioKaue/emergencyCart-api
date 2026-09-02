using EmergencyCart.Domain.AccountContext.ValueObjects;
using EmergencyCart.Domain.SharedContext.AggregateRoots.Abstractions;
using EmergencyCart.Domain.SharedContext.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmergencyCart.Domain.AccountContext.Entities;

public sealed class Sector : Entity, IAggregateRoots
{
    #region List of EmergencyCarts
    private readonly List<EmergencyCart> _emergencyCarts;
    #endregion

    #region Constructors

    private Sector() : base(Guid.CreateVersion7()) { }
    private Sector(Guid id, string name) : base(id)
    {
        _emergencyCarts = [];
        Names = name;

        IsActive = true;
    }
    #endregion

    #region Properties
    public string Names { get; }
    public bool IsActive { get; } = false;
    #endregion

    #region Relationships
    public IReadOnlyCollection<EmergencyCart> EmergencyCarts => _emergencyCarts.ToArray();
    #endregion


    #region Factory Method
    private static void Validate(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Nome do setor não pode ser vazio.");

        if (name.Trim().Length < 3)
            throw new Exception("Nome do setor muito curto.");
    }

    public static Sector Create(string name)
    {
        Validate(name);

        var id = Guid.NewGuid();
        var formattedName = Name.FormatName(name);

        return new Sector(id, formattedName);
    }
    #endregion
}
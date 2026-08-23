namespace EmergencyCart.Domain.SharedContext.Entities;

public abstract class Entity(Guid id) : IEquatable<Guid>
{
    public Guid Id { get; } = id;

    public bool Equals(Guid otherId) => Id == otherId;
}

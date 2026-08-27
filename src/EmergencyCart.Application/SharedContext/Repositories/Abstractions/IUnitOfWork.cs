namespace EmergencyCart.Application.SharedContext.Repositories.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
    Task RoolBackAsync(CancellationToken cancellationToken);
}

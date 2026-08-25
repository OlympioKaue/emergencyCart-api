namespace EmergencyCart.Application.SharedContext.Repositories.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RoolBackAsync();
}

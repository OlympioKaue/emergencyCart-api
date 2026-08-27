using EmergencyCart.Application.SharedContext.Repositories.Abstractions;
using EmergencyCart.Infrastructure.SharedContext.Data;

namespace EmergencyCart.Infrastructure.AccountContext.Repositories.Abstractions;

internal class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken cancellationToken)
    => await dbContext.SaveChangesAsync(cancellationToken);

    public async Task RoolBackAsync(CancellationToken cancellationToken)
    => await Task.CompletedTask;
}

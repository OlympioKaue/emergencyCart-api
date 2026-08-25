using EmergencyCart.Application.SharedContext.Repositories.Abstractions;
using EmergencyCart.Infrastructure.SharedContext.Data;

namespace EmergencyCart.Infrastructure.AccountContext.Repositories.Abstractions;

internal class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public async Task CommitAsync()
    => await dbContext.SaveChangesAsync();

    public async Task RoolBackAsync()
    => await Task.CompletedTask;
}

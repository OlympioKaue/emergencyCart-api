using EmergencyCart.Application.AccountContext.Repositories.Abstractions;
using EmergencyCart.Infrastructure.SharedContext.Data;

namespace EmergencyCart.Infrastructure.AccountContext.Repositories.Abstractions;

public sealed class EmergencyCartRepository(AppDbContext dbContext) : IEmergencyCartRepository
{
    public async Task AddAsync(Domain.AccountContext.Entities.EmergencyCart emergencyCart, CancellationToken cancellationToken)
    {
        await dbContext.EmergencyCarts.AddAsync(emergencyCart, cancellationToken);
    }
}

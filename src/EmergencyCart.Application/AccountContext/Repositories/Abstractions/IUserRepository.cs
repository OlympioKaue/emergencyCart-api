using EmergencyCart.Application.SharedContext.Repositories.Abstractions;
using EmergencyCart.Domain.AccountContext.Entities;

namespace EmergencyCart.Application.AccountContext.Repositories.Abstractions;

public interface IUserRepository : IRepository<User>
{
    Task AddUserAsync(User user, CancellationToken cancellationToken);
    Task<bool> VerifyEmailExistsAsync(string email, CancellationToken cancellationToken);
}

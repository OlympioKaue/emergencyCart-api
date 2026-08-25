using EmergencyCart.Application.SharedContext.Repositories.Abstractions;
using EmergencyCart.Domain.AccountContext.Entities;

namespace EmergencyCart.Application.AccountContext.Repositories.Abstractions;

public interface IUserRepository : IRepository<User>
{
    Task AddUser(User user);
    Task<bool> VerifyEmailExistsAsync(string email);
}

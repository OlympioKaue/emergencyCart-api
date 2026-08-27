using EmergencyCart.Application.AccountContext.Repositories.Abstractions;
using EmergencyCart.Domain.AccountContext.Entities;
using EmergencyCart.Infrastructure.SharedContext.Data;
using Microsoft.EntityFrameworkCore;

namespace EmergencyCart.Infrastructure.AccountContext.Repositories.Abstractions;

internal class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    => await dbContext.Users.AddAsync(user, cancellationToken);

    public async Task<User?> GetUserAsync(Guid id)
    => await dbContext.Users.FirstOrDefaultAsync(y => y.Id == id);

    public void UpdateAsync(User user, CancellationToken cancellationToken)
    {
        dbContext.Users.Update(user);

    }

    public async Task<bool> VerifyEmailExistsAsync(string email, CancellationToken cancellationToken)
    => await dbContext.Users.AsNoTracking().AnyAsync(y => y.Email.Address == email, cancellationToken);

}

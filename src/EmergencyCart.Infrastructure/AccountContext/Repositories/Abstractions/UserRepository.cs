using EmergencyCart.Application.AccountContext.Repositories.Abstractions;
using EmergencyCart.Domain.AccountContext.Entities;
using EmergencyCart.Infrastructure.SharedContext.Data;
using Microsoft.EntityFrameworkCore;

namespace EmergencyCart.Infrastructure.AccountContext.Repositories.Abstractions;

internal class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public async Task AddUser(User user)
    => await dbContext.Users.AddAsync(user);

    public async Task<bool> VerifyEmailExistsAsync(string email)
    => await dbContext.Users.AsNoTracking().AnyAsync(y => y.Email.Address == email);

}

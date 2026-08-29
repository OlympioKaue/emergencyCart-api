using EmergencyCart.Application.SharedContext.UseCases.Abstractions;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Delete;

public sealed record class Command(Guid id) : ICommand<Response>
{
}

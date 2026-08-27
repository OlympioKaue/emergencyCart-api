using EmergencyCart.Application.SharedContext.Results;
using EmergencyCart.Application.SharedContext.UseCases.Abstractions;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Update;

public sealed record class Command(Guid id, string? firstName = default, string? lastName = default, string? email = default) : ICommand<Response>
{
}

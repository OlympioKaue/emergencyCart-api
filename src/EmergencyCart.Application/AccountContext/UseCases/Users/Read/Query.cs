using EmergencyCart.Application.SharedContext.UseCases.Abstractions;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Read;

public sealed record Query(Guid id) : IQuery<Response>
{
}

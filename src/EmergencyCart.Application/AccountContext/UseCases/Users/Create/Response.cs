using EmergencyCart.Application.SharedContext.UseCases.Abstractions;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Create;

public sealed record class Response(string message) : ICommandResponse
{
}

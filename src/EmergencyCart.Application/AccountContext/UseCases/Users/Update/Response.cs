using EmergencyCart.Application.SharedContext.UseCases.Abstractions;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Update;

public sealed record class Response(string message) : ICommandResponse
{
}

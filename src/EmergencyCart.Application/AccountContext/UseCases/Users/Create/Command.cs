using EmergencyCart.Application.SharedContext.UseCases.Abstractions;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Create;

public sealed record class Command(
    string firstName, string lastName, string email, string password) : ICommand<Response>
{
}

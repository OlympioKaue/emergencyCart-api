using EmergencyCart.Application.SharedContext.UseCases.Abstractions;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Read
{
    public sealed record class Response(Guid id, string firstName, string lastName) : IQueryResponse
    {
    }
}

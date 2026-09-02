using EmergencyCart.Application.SharedContext.UseCases.Abstractions;
using MediatR;
using System.Windows.Input;

namespace EmergencyCart.Application.AccountContext.UseCases.EmergencyCarts.Create;

public sealed record class Command(
    Guid id ) : ICommand<Response>
{
}

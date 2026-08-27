using EmergencyCart.Application.AccountContext.Repositories.Abstractions;
using EmergencyCart.Application.SharedContext.Repositories.Abstractions;
using EmergencyCart.Application.SharedContext.Results;
using EmergencyCart.Application.SharedContext.UseCases.Abstractions;
using EmergencyCart.Domain.AccountContext.ValueObjects;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Update;

public sealed class Handler(IUserRepository _userRepository, IUnitOfWork _ofWork) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        //VERIFICAR SE O ID EXISTE
        var user = await _userRepository.GetUserAsync(request.id);
        if (user is null)
            return Result.Failure<Response>(Error.NullValue);

        //GERA AQUILO QUE EU QUERO ATUALIZAR.
        user.ChangeNameUpdate(request.firstName, request.lastName);

        user.ChangeEmailUpdate(request.email);

        _userRepository.UpdateAsync(user, cancellationToken);

        //PERSISTIR OS DADOS
        await _ofWork.CommitAsync();

        return Result.Success(new Response("Atualizado com sucesso"));
    }
}

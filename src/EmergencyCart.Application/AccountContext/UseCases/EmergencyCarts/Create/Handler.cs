using EmergencyCart.Application.AccountContext.Repositories.Abstractions;
using EmergencyCart.Application.AccountContext.Repositories.Abstractions.CodeGenerator;
using EmergencyCart.Application.SharedContext.Repositories.Abstractions;
using EmergencyCart.Application.SharedContext.Results;
using EmergencyCart.Application.SharedContext.UseCases.Abstractions;

namespace EmergencyCart.Application.AccountContext.UseCases.EmergencyCarts.Create;

public sealed class Handler
    (ICartCodeGenerator cartCodeGenerator,
    ISectorRepository sectorRepository,
    IEmergencyCartRepository emergencyCartRepository,
    IUnitOfWork ofWork) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var sector = await sectorRepository.GetByIdAsync(request.id, cancellationToken);
        if (sector is null)
            return Result.Failure<Response>(Error.NotFound("404", "The specified sector was not found."));

        var code = await cartCodeGenerator.GenerateCodeAsync(cancellationToken);

        var cart = EmergencyCart.Domain.AccountContext.Entities.EmergencyCart.Create(sector.Id, code);

        await emergencyCartRepository.AddAsync(cart, cancellationToken);
        await ofWork.CommitAsync(cancellationToken);

        return Result.Success(new Response("Emergency cart created successfully."));

    }
}

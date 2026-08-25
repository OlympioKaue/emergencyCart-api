using EmergencyCart.Application.SharedContext.Results;
using MediatR;

namespace EmergencyCart.Application.SharedContext.UseCases.Abstractions;

public interface ICommand : IRequest<Result>;

public interface ICommand<TCommandResponse> : IRequest<Result<TCommandResponse>> where TCommandResponse : ICommandResponse;

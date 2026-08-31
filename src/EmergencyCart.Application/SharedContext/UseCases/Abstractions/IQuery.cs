using EmergencyCart.Application.SharedContext.Results;
using MediatR;

namespace EmergencyCart.Application.SharedContext.UseCases.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IQueryResponse
{
}

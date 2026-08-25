using FluentValidation;
using MediatR;

namespace EmergencyCart.Application.SharedContext.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any() is false)
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = validators
            .Select(x => x.Validate(context))
            .Where(x => x.Errors.Any())
            .SelectMany(x => x.Errors)
            .Select(x => new ValidationError(x.PropertyName, x.ErrorMessage))
            .ToList();

        if (validationResults.Any())
            throw new ValidationException(validationResults);

        return await next();
    }

    public sealed class ValidationException : SystemException
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        => Errors = errors;

        public IEnumerable<ValidationError> Errors { get; }
    }

    public sealed record class ValidationError(string PropertyName, string ErrorMessage);

}
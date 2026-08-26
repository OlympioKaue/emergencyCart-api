using EmergencyCart.Application.SharedContext.Results;
using EmergencyCart.Application.SharedContext.Results.Enums;
using EmergencyCart.Application.SharedContext.Results;

public sealed class ValidationException : SystemException
{
    public ValidationException(IEnumerable<ValidationError> errors)
    => Errors = errors;

    public IEnumerable<ValidationError> Errors { get; }
}

public sealed record class ValidationError(List<Error> Errors) : Error("Validation.General", "Um ou mais erros de validação ocorreram.", ErrorType.BadRequest);
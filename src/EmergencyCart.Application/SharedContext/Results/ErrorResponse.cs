namespace EmergencyCart.Application.SharedContext.Results;

public sealed record class ErrorResponse(IReadOnlyCollection<string> errors)
{
    public static ErrorResponse From(Error error) => error is ValidationError validationError
        ? new ErrorResponse(validationError.Messages)
        : new ErrorResponse([error.Message]);
}

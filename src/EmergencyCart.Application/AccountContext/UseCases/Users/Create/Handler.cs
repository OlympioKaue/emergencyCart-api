using EmergencyCart.Application.AccountContext.Repositories.Abstractions;
using EmergencyCart.Application.SharedContext.Repositories.Abstractions;
using EmergencyCart.Application.SharedContext.Results;
using EmergencyCart.Application.SharedContext.Results.Enums;
using EmergencyCart.Application.SharedContext.UseCases.Abstractions;
using EmergencyCart.Domain.AccountContext.Entities;
using EmergencyCart.Domain.AccountContext.ValueObjects;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Create;

public sealed class Handler(IUserRepository userRepository, IUnitOfWork ofWork) : ICommandHandler<Command, Response>
{
    private const string Welcome = "Usuario cadastrado com sucesso!";

    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var validationResult = Validate(request);
        if (validationResult.IsFailure)
            return Result.Failure<Response>(validationResult.Error);

        var emailExists = await userRepository.VerifyEmailExistsAsync(request.email, cancellationToken);
        if (emailExists)
            return Result.Failure<Response>(Error.Conflict("User.Conflict", "E-mail already in use"));

        var name = Name.Create(request.firstName, request.lastName);

        var email = Email.Create(request.email);

        var password = Password.Create(request.password);

        var user = User.Create(name, email, password);

        await userRepository.AddUserAsync(user, cancellationToken);
        await ofWork.CommitAsync();

        var response = new Response(Welcome);
        return Result.Success(response);
    }

    private static Result Validate(Command request)
    {
        var validation = new Validator();
        var result = validation.Validate(request);
        if (result.IsValid)
            return Result.Success();

        var errors = result.Errors.Select(e => e.ErrorMessage).ToArray();

        return Result.Failure<Response>(new ValidationError(errors));
    }
}

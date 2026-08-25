using EmergencyCart.Application.AccountContext.Repositories.Abstractions;
using EmergencyCart.Application.SharedContext.Repositories.Abstractions;
using EmergencyCart.Application.SharedContext.Results;
using EmergencyCart.Application.SharedContext.UseCases.Abstractions;
using EmergencyCart.Domain.AccountContext.Entities;
using EmergencyCart.Domain.AccountContext.ValueObjects;

namespace EmergencyCart.Application.AccountContext.UseCases.Users.Create;

public sealed class Handler(IUserRepository userRepository, IUnitOfWork ofWork) : ICommandHandler<Command, Response>
{
    private const string Welcome = "Usuario cadastrado com sucesso!";

    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        //VERIFICAR SE EMAIL EXISTE!
        var emailExists = await userRepository.VerifyEmailExistsAsync(request.email);
        if (emailExists)
            return Result.Failure<Response>(new Error("403", "......"));

        //CRIAR O NOME
        var name = Name.Create(request.firstName, request.lastName);

        //CRIAR O EMAIL
        var email = Email.Create(request.email);

        //CRIAR O PASSWORD
        var password = Password.Create(request.password);

        //CRIAR O USUARIO
        var user = User.Create(name, email, password);

        //PERSISTIR DADOS
        await userRepository.AddUser(user);
        await ofWork.CommitAsync();

        //RETORNAR MENSAGEM AO USUARIO.
        var response = new Response(user.Id, Welcome);
        return Result.Success(response);
    }
}

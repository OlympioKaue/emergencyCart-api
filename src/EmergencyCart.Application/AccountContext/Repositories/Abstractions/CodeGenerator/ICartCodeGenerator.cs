using EmergencyCart.Application.SharedContext.Repositories.Abstractions;

namespace EmergencyCart.Application.AccountContext.Repositories.Abstractions.CodeGenerator;

public interface ICartCodeGenerator
{
    Task<string> GenerateCodeAsync(CancellationToken cancellationToken);
}

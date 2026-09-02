using EmergencyCart.Application.AccountContext.Repositories.Abstractions.CodeGenerator;
using EmergencyCart.Infrastructure.SharedContext.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmergencyCart.Infrastructure.AccountContext.Repositories.Abstractions.CodeGenerator;

public sealed class CartCodeGenerator(AppDbContext dbContext) : ICartCodeGenerator
{
    public async Task<string> GenerateCodeAsync(CancellationToken cancellationToken)
    {
        var connection = dbContext.Database.GetDbConnection();

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(cancellationToken);

        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT NEXT VALUE FOR dbo.EmergencyCartCodeSequence";

        var result = await command.ExecuteScalarAsync(cancellationToken);
        var nextValue = Convert.ToInt32(result);

        return $"CART-{nextValue:D4}";
    }
}

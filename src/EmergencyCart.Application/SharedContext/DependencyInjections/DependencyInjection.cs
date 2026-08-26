using Microsoft.Extensions.DependencyInjection;

namespace EmergencyCart.Application.SharedContext.DependencyInjections;

public static class DependencyInjection
{
    public static void AddApplicationSharedContext(this IServiceCollection services)
    {
        AddMediatR(services);
    }

    private static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
           
        });
    }
}

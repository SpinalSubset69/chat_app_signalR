using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SignalRDemoChat.Application.CommandHandlers;
using SignalRDemoChat.Application.Contracts;
using SignalRDemoChat.Infrastructure.DbAccess;

namespace SignalRDemoChat.Application;

public static class AppServices
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlite(connectionString, b => b.MigrationsAssembly("SignalRDemoChat.API")));
        return services;
    }

    public static IServiceCollection AddMediatRAppHandlers(this IServiceCollection services) 
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateRoomHandler).Assembly));

        return services;
    }

    public static IServiceCollection AddAppUnitOfWork(this IServiceCollection services) 
    {
        services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
        return services;
    }        
}

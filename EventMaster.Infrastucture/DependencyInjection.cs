using EventMaster.Application.Common.Interfaces.Services;
using EventMaster.Infrastructure.Persistence;
using EventMaster.Infrastructure.Persistence.Repositories;
using EventMaster.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Amazon.SimpleEmailV2;
using Amazon.CognitoIdentityProvider;
using EventMaster.Application.Common.Interfaces.Persistence;

namespace EventMaster.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
        .AddDB(configuration)
        .AddAuth(configuration)
        .AddPersistance();
        // Environment.SetEnvironmentVariable("AWS_PROFILE", "myacc");

        services.AddDefaultAWSOptions(configuration.GetAWSOptions());
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IAuthProvider, AuthProvider>();
        services.AddSingleton<IEmailProvider, EmailProvider>();
        services.AddSingleton<IAmazonSimpleEmailServiceV2, AmazonSimpleEmailServiceV2Client>();
        services.AddSingleton<IAmazonCognitoIdentityProvider, AmazonCognitoIdentityProviderClient>();

        return services;
    }

    public static IServiceCollection AddPersistance(
        this IServiceCollection services)
    {
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();
        services.AddScoped<IEventReviewRepository, EventReviewRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
    {
        return services;
    }

    public static IServiceCollection AddDB(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

        services.AddDbContext<EventMasterDbContext>(
                   (sp, optionsBuilder) =>
                   {
                       optionsBuilder
                          .UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion)

                          // The following three options help with debugging, but should
                          // be changed or removed for production.
                          .LogTo(Console.WriteLine, LogLevel.Information)
                          .EnableSensitiveDataLogging()
                          .EnableDetailedErrors();
                   }
                );

        return services;
    }
}
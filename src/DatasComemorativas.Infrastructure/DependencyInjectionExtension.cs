using DataComemorativa.Domain.Repositories.DataComemorativa;
using DataComemorativa.Infrastructure.DataAcess;
using DataComemorativa.Infrastructure.DataAcess.Repositories;
using DataComemorativa.Infrastructure.DataAcess.Repositories.DataComemorativa;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace DataComemorativa.Infrastructure;


public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddFluentMigrator(services, configuration);
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IDataComemorativaRepository, DataComemorativaRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var conectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 43));

        services.AddDbContext<DataComemorativaDbContext>(options =>
        {
            options.UseMySql(conectionString, serverVersion);
        });
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        var infrastructureAssembly = Assembly.Load("DataComemorativa.Infrastructure");
        var connectionString = configuration.GetConnectionString("Connection");

        services.AddFluentMigratorCore()
            .ConfigureRunner(config =>
            {
                config.AddMySql8()
                      .WithGlobalConnectionString(connectionString)
                      .ScanIn(infrastructureAssembly).For.Migrations();
            })
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }
}


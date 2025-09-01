using DataComemorativa.Domain.Repositories.DataComemorativa;
using DataComemorativa.Infrastructure.DataAcess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataComemorativa.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDataComemorativaRepository, DataComemorativaRepository>();
    }
}


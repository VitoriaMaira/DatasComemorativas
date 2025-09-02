using DataComemorativa.Application.UseCases.DataComemorativa.Register;
using Microsoft.Extensions.DependencyInjection;

namespace DataComemorativa.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRegisterDataComemorativaUseCase, RegisterDataComemorativaUseCase>();
        }
    }
}

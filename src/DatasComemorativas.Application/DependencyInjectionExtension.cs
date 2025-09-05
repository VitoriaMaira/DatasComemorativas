using DataComemorativa.Application.UseCases.DataComemorativa.Delete;
using DataComemorativa.Application.UseCases.DataComemorativa.GetAll;
using DataComemorativa.Application.UseCases.DataComemorativa.Register;
using DataComemorativa.Application.UseCases.DataComemorativa.Update;
using Microsoft.Extensions.DependencyInjection;

namespace DataComemorativa.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRegisterDataComemorativaUseCase, RegisterDataComemorativaUseCase>();
            services.AddScoped<IGetAllDataComemorativaUseCase, GetAllDataComemorativaUseCase>();
            services.AddScoped<IDeleteDataComemorativaUseCase, DeleteDataComemorativaUseCase>();
            services.AddScoped<IUpdateDataComemorativaUseCase, UpdateDataComemorativaUseCase>();

            
        }
    }
}

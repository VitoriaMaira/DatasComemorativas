using DataComemorativa.Communication.Responses;

namespace DataComemorativa.Application.UseCases.DataComemorativa.GetAll
{
    public interface IGetAllDataComemorativaUseCase
    {
        Task<ResponseDataComemorativaGetAll> Execute();
    }
}

using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Delete;
public interface IDeleteDataComemorativaUseCase
{
    Task<ResponseDeleteDataComemorativa> Execute(int id, RequestDeleteDataComemorativa request);
}

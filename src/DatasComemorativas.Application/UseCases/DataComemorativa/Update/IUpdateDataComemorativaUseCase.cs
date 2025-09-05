using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Update;
public interface IUpdateDataComemorativaUseCase
{
    Task<ResponseRegisterDataComemorativa> Execute(int id, RequestRegisterDataComemorativa request);
}

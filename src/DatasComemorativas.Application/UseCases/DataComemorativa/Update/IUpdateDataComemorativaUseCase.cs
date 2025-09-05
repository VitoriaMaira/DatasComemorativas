using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Update;
public interface IUpdateDataComemorativaUseCase
{
 Task<ResponseUpdateDataComemorativa> Execute(int id, RequestDataComemorativa request);
}

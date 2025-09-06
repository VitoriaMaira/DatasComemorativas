using DataComemorativa.Communication.Requests;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Update;
public interface IUpdateDataComemorativaUseCase
{
    Task<ResponseDataComemorativaUpdate> Execute(RequestDataComemorativaUpdate request);
}

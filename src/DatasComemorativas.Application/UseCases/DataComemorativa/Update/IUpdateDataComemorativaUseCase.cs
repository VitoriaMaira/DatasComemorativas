using DataComemorativa.Communication.Requests;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Update;
public interface IUpdateDataComemorativaUseCase
{
    Task Execute(int id, RequestRegisterDataComemorativa request);

}

using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Register
{
    public interface IRegisterDataComemorativaUseCase
    {
        Task<ResponseRegisterDataComemorativa> Execute(RequestDataComemorativaRegister request);
    }
}

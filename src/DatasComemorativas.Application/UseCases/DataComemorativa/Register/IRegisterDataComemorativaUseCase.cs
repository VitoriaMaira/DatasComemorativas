using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Register
{
    public interface IRegisterDataComemorativaUseCase
    {
        Task<ResponseRegisterDataComemorativa> Execute(RequestDataComemorativa request);
    }
}

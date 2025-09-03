using DataComemorativa.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComemorativa.Application.UseCases.DataComemorativa.GetAll
{
    public interface IGetAllDataComemorativaUseCase
    {
        Task<ResponseDataComemorativa> Execute();
    }
}

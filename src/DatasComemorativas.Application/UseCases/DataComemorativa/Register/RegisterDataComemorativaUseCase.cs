using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;
using DataComemorativa.Domain.Repositories.DataComemorativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Register
{
    public class RegisterDataComemorativaUseCase : IRegisterDataComemorativaUseCase
    {
        private readonly IDataComemorativaRepository _dataComemorativaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterDataComemorativaUseCase(IDataComemorativaRepository dataComemorativaRepository,
            IUnitOfWork unitOfWork)
        {
            _dataComemorativaRepository = dataComemorativaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RegisterDataComemorativaResponse> Execute(RegisterDataComemorativaRequest request)
        {
            var data = new Domain.Entities.Data
            {
                Name = request.Name,
                Date = request.Date,
                Descryption = request.Description
            };
            await _dataComemorativaRepository.AddAsync(data);

            return new RegisterDataComemorativaResponse ("Data inserida comn sucesso");
        }
    }

    //public void Validate(RegisterDataComemorativaRequest request)
}

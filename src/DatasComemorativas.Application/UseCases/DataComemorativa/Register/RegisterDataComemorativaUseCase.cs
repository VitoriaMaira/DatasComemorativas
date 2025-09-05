using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;
using DataComemorativa.Domain.Repositories.DataComemorativa;
using DataComemorativa.Exception.ExceptionBase;

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

        public async Task<ResponseRegisterDataComemorativa> Execute(RequestDataComemorativa request)
        {
            Validate(request);

            var data = new Domain.Entities.Data
            {
                Name = request.Name,
                Date = request.Date,
                Description = request.Description
            };
            await _dataComemorativaRepository.AddAsync(data);

            await _unitOfWork.Commit();

            return new ResponseRegisterDataComemorativa("Data inserida com sucesso");
        }


        private void Validate(RequestDataComemorativa request)
        {
            var validator = new DataComemorativaValidator();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }

        }
    }
}

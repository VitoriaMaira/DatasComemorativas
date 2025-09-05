using DataComemorativa.Communication.Requests;
using DataComemorativa.Domain.Repositories.DataComemorativa;
using DataComemorativa.Exception.ExceptionBase;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Update;
public class UpdateDataComemorativaUseCase : IUpdateDataComemorativaUseCase
{
    private readonly IDataComemorativaRepository _dataComemorativaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDataComemorativaUseCase(
        IDataComemorativaRepository repository,
        IUnitOfWork unitOfWork)
    {
        _dataComemorativaRepository = repository;
        _unitOfWork = unitOfWork;

    }

    public async Task Execute(int id, RequestRegisterDataComemorativa request)
    {
        Validate(request);
        
        var dataComemorativa = await _dataComemorativaRepository.GetByIdAsync(id);
        if (dataComemorativa is null)
            throw new NotFoundException("Data comemorativa não encontrada.");
        
        dataComemorativa.Name = request.Name;
        dataComemorativa.Date = request.Date;
        dataComemorativa.Description = request.Description;
        
        await _unitOfWork.Commit();
    }

    private void Validate(RequestRegisterDataComemorativa request)
    {
        var validator = new DataComemorativaValidator();

        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

        //if (string.IsNullOrWhiteSpace(request.Name))
        //{
        //    throw new ArgumentException("Nome é obrigatório.");
        //}
        //if (request.Date == default)
        //{
        //    throw new ArgumentException("Data é obrigatória.");
        //}
    }
}

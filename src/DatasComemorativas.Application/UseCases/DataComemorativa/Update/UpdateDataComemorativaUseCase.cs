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

    public async Task<ResponseDataComemorativaUpdate> Execute(RequestDataComemorativaUpdate request)
    {
        Validate(request);

        var dataComemorativa = await _dataComemorativaRepository.GetByIdAsync(request.Id);
        if (dataComemorativa is null)
            throw new NotFoundException("Data comemorativa não encontrada.");

        dataComemorativa.Name = request.Name;
        dataComemorativa.Date = request.Date;
        dataComemorativa.Description = request.Description;

        await _dataComemorativaRepository.UpdateAsync(dataComemorativa);
        await _unitOfWork.Commit();

        return new ResponseDataComemorativaUpdate(request.Id, "Data comemorativa atualizada com sucesso.");
    }

    private void Validate(RequestDataComemorativaUpdate request)
    {
        var validator = new RequestDataComemorativaUpdateValidator();

        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }


    }
}

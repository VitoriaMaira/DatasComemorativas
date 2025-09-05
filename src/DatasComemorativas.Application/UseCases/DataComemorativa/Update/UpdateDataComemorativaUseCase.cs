using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;
using DataComemorativa.Domain.Repositories.DataComemorativa;
using DataComemorativa.Exception.ExceptionBase;
using FluentValidation;

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

    public async Task<ResponseUpdateDataComemorativa> Execute(int id, RequestDataComemorativa request)
    {
        Validate(request);

        var dataComemorativa = await _dataComemorativaRepository.GetByIdAsync(id);
        if (dataComemorativa is null)
            throw new NotFoundException("Data comemorativa não encontrada.");

        dataComemorativa.Name = request.Name;
        dataComemorativa.Date = request.Date;
        dataComemorativa.Description = request.Description;

        await _unitOfWork.Commit();

        return new ResponseUpdateDataComemorativa(id, "Data comemorativa atualizada com sucesso.");
    }

    private void Validate(RequestDataComemorativa request)
    {
        var validator = new DataComemorativaValidator();

        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }


    }
}

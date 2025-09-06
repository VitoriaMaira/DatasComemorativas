using DataComemorativa.Communication.Requests;
using DataComemorativa.Communication.Responses;
using DataComemorativa.Domain.Repositories.DataComemorativa;
using DataComemorativa.Exception.ExceptionBase;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Delete;


public class DeleteDataComemorativaUseCase : IDeleteDataComemorativaUseCase
{
    private readonly IDataComemorativaRepository _dataComemorativaRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteDataComemorativaUseCase(IDataComemorativaRepository dataComemorativaRepository, IUnitOfWork unitOfWork)
    {
        _dataComemorativaRepository = dataComemorativaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDeleteDataComemorativa> Execute(RequestDataComemorativaDelete request)
    {
        Validate(request);

        var data = await _dataComemorativaRepository.GetByIdAsync(request.Id);

        if (data is null)
            throw new NotFoundException("Data não encontrada.");

        await _dataComemorativaRepository.DeleteAsync(data);
        await _unitOfWork.Commit();

        return new ResponseDeleteDataComemorativa(request.Id, "Data deletada com sucesso.");
    }

    private void Validate(RequestDataComemorativaDelete request)
    {
        var validator = new RequestDataComemorativaDeleteValidator();

        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }

    }

}
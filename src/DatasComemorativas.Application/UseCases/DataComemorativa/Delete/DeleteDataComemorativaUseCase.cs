using DataComemorativa.Domain.Repositories.DataComemorativa;
using DataComemorativa.Exception.ExceptionBase;
using System.Reflection;

namespace DataComemorativa.Application.UseCases.DataComemorativa.Delete;
public class DeleteDataComemorativaUseCase : IDeleteDataComemorativaUseCase
{
    private readonly IDataComemorativaRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteDataComemorativaUseCase(IDataComemorativaRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(int id)
    {
        var data = await _repository.GetByIdAsync(id);

        if (data is null)
        {
            throw new NotFoundException("Data não encontrada.");
        }
        

        await _repository.DeleteAsync(id);
        await _unitOfWork.Commit();
    }
}
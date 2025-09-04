using DataComemorativa.Domain.Repositories.DataComemorativa;

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

    public async Task Execute(int id)
    {
        var entity = await _dataComemorativaRepository.GetByIdAsync(id);

        if (entity == null)
        {
            // Você pode lançar uma exceção ou apenas retornar
            return;
        }

        await _dataComemorativaRepository.DeleteAsync(entity);
        await _unitOfWork.Commit();
    }
}
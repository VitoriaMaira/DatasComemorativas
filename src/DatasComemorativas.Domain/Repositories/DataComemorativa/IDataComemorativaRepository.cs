using DataComemorativa.Domain.Entities;

namespace DataComemorativa.Domain.Repositories.DataComemorativa
{
    public interface IDataComemorativaRepository
    {
        Task AddAsync(Data entity);
        Task<List<Data>> GetAllAsync();
        Task<Data?> GetByIdAsync(int id);
        Task UpdateAsync(Data entity);
        Task DeleteAsync(Data entity);


    }
}

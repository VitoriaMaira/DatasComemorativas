using DataComemorativa.Domain.Entities;

namespace DataComemorativa.Domain.Repositories.DataComemorativa
{
    public interface IDataComemorativaRepository
    {
        Task AddAsync(Data data);
        Task<List<Data>> GetAllAsync();
        Task UpdateAsync(Data data);
        Task DeleteAsync(int id); 
    }
}

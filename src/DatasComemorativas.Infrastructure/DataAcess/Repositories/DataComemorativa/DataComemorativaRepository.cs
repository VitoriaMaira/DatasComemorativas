using DataComemorativa.Domain.Entities;
using DataComemorativa.Domain.Repositories.DataComemorativa;
using Microsoft.EntityFrameworkCore;

namespace DataComemorativa.Infrastructure.DataAcess.Repositories
{
    //serve 
    public class DataComemorativaRepository : IDataComemorativaRepository
    {
        private readonly DataComemorativaDbContext _dbContext;
        public DataComemorativaRepository(DataComemorativaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Data data)
        {
            await _dbContext.Datas.AddAsync(data);
        }

        public async Task DeleteAsync(Data data)
        {
            _dbContext.Datas.Remove(data);
            await Task.CompletedTask;
        }

        public Task<List<Data>> GetAllAsync()
        {
            return _dbContext.Datas.ToListAsync();
        }

        public async Task UpdateAsync(Data data)
        {
            _dbContext.Datas.Update(data);
            await Task.CompletedTask;
        }
    }
}

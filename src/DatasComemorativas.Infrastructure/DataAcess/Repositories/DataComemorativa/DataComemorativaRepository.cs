using DataComemorativa.Domain.Entities;
using DataComemorativa.Domain.Repositories.DataComemorativa;
using Microsoft.EntityFrameworkCore;

namespace DataComemorativa.Infrastructure.DataAcess.Repositories
{
    
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


        public async Task DeleteAsync(int id)
        {
            var data = await _dbContext.Datas.FindAsync(id);
            if (data != null)
            {
                _dbContext.Datas.Remove(data);
            }
            await Task.CompletedTask;
        }

        public async Task<List<Data>> GetAllAsync()
        {
            return await _dbContext.Datas.ToListAsync();
        }

        public async Task<Data> GetByIdAsync(int id)
        {
            return await _dbContext.Datas.FindAsync(id);
        }

        public async Task UpdateAsync(Data data)
        {
            _dbContext.Datas.Update(data);
            await Task.CompletedTask;
        }


    }
}

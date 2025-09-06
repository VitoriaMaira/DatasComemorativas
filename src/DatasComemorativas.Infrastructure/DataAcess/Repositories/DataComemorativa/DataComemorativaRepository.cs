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

        public async Task AddAsync(Data entity)
        {
            await _dbContext.Datas.AddAsync(entity);
        }


        public async Task DeleteAsync(Data entity)
        {
            _dbContext.Datas.Remove(entity);

            await Task.CompletedTask;
        }

        public async Task<List<Data>> GetAllAsync()
        {
            return await _dbContext.Datas.ToListAsync();
        }

        public async Task<Data?> GetByIdAsync(int id)
        {
            return await _dbContext.Datas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Data entity)
        {
            _dbContext.Datas.Update(entity);
            await Task.CompletedTask;
        }


    }
}

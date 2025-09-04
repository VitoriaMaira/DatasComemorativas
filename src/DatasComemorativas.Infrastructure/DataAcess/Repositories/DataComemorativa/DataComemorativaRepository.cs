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
            await Task.CompletedTask; // Para manter assinatura async
        }

        public async Task<List<Data>> GetAllAsync()
        {
            return await _dbContext.Datas.ToListAsync();
        }

        public Task<Data> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }



        //public async Task<Data> Update()
    }
}

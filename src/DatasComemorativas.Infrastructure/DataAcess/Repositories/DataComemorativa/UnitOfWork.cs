using DataComemorativa.Domain.Repositories.DataComemorativa;

namespace DataComemorativa.Infrastructure.DataAcess.Repositories.DataComemorativa
{
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataComemorativaDbContext _context;

        public UnitOfWork(DataComemorativaDbContext context)
        {
            _context = context;
        }

        public async Task Commit() => await _context.SaveChangesAsync();

    }
}

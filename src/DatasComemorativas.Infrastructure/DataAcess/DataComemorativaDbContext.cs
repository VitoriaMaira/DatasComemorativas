using Microsoft.EntityFrameworkCore;


namespace DataComemorativa.Infrastructure.DataAcess
{
    public class DataComemorativaDbContext : DbContext
    {
        public DataComemorativaDbContext(DbContextOptions<DataComemorativaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

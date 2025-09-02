using Microsoft.EntityFrameworkCore;
using DataComemorativa.Domain.Entities;
using DataComemorativa.Infrastructure.DataAccess.Mappings;


namespace DataComemorativa.Infrastructure.DataAcess
{
    public class DataComemorativaDbContext : DbContext
    {
        public DataComemorativaDbContext(DbContextOptions<DataComemorativaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DataMap());
        }
    }
}

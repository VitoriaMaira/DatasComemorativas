using Microsoft.EntityFrameworkCore;
using DataComemorativa.Domain.Entities;


namespace DataComemorativa.Infrastructure.DataAcess
{
    public class DataComemorativaDbContext : DbContext
    {
        
        public DbSet<Data> datas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=data_comemorativa;user=root;password=root";
            
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 43)); // Adjust version as needed
            
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}

using DataComemorativa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataComemorativa.Infrastructure.DataAccess.Mappings;
internal class DataMap : IEntityTypeConfiguration<Data>
{
    public void Configure(EntityTypeBuilder<Data> builder)
    {
        // Define a tabela que será usada
        builder.ToTable("datas");

        // Define a chave primária
        builder.HasKey(d => d.Id);

        // Mapeamento das colunas
        builder.Property(d => d.Id).HasColumnName("id");
        builder.Property(d => d.Name).HasColumnName("name");
        builder.Property(d => d.Date).HasColumnName("date");
        builder.Property(d => d.Description).HasColumnName("descryption");
    }
}

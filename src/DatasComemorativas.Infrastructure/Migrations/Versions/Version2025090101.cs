using System;
using DataComemorativa.Infrastructure.Migrations;
using FluentMigrator;

namespace DataComemorativa.Infrastructure.Migrations.Versions
{
    [Migration(DatabaseVersions.CRIANDO_TABELA_DATAS, "Criando tabela datas")]
    public class Version2025090101 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("datas")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(255).NotNullable()
                .WithColumn("date").AsDateTime().NotNullable()
                .WithColumn("descryption").AsString(int.MaxValue).Nullable();
            // No MySQL, FluentMigrator traduz para LONGTEXT
        }
    }
}

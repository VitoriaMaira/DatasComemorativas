using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System;
using System.Linq;

namespace DataComemorativa.Infrastructure.Migrations
{
    public class DatabaseMigration
    {
        public static void Migrate(string connectionString, IServiceProvider serviceProvider)
        {
            EnsureDatabaseCreatedForMySql(connectionString);

            MigrateDatabase(serviceProvider);
        }

        private static void EnsureDatabaseCreatedForMySql(string connectionString)
        {
            var builder = new MySqlConnectionStringBuilder(connectionString);
            var databaseName = builder.Database;

            // Remover o nome do banco para conectar apenas no servidor
            builder.Database = string.Empty;

            using var dbConnection = new MySqlConnection(builder.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", parameters);

            if (!records.Any())
            {
                dbConnection.Execute($"CREATE DATABASE `{databaseName}` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;");
            }
        }

        private static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();
            runner.MigrateUp();
        }
    }
}


using DataComemorativa.Api.Filters;
using DataComemorativa.Application;
using DataComemorativa.Infrastructure;
using DataComemorativa.Infrastructure.Migrations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));


var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();

// Faz a migração do banco de dados
async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();

    var connectionString = builder.Configuration.GetConnectionString("Connection");

    DatabaseMigration.Migrate(connectionString, scope.ServiceProvider);
}
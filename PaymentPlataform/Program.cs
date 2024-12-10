using Microsoft.EntityFrameworkCore;
using PaymentPlataform.Extensions;
using PaymentPlataform.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Default") ?? string.Empty;

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString)
);

builder.Services
    .AddHealthChecks()
    .AddSqlServer(connectionString, timeout: TimeSpan.FromSeconds(10));

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/healthcheck");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

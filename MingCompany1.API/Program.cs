using Microsoft.EntityFrameworkCore;
using MingCompany.Infrastructure.Data;
using MingCompany.Infrastructure.Repositories;
using MingCompany.Domain.Services;
using MingCompany.Domain.Entities;
using MingCompany.Application.Services;
using MingCompany.Application.Handlers;
using MingCompany.Application.Commands;
using MingCompany.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Database Configuration
builder.Services.AddDbContext<MiningDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de dependencias
RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MiningDbContext>();
    context.Database.EnsureCreated();
}

app.Run();

void RegisterServices(IServiceCollection services)
{
    // Infrastructure
    services.AddScoped<IOperationRepository, OperationRepository>();
    
    // Domain
    services.AddScoped<IOperationDomainService, OperationDomainService>();
    
    // Application Handlers
    services.AddScoped<ICommandHandler<CreateOperationCommand, Operation>, CreateOperationHandler>();
    services.AddScoped<ICommandHandler<DeleteOperationCommand, bool>, DeleteOperationHandler>();
    services.AddScoped<IQueryHandler<GetAllOperationsQuery, List<Operation>>, GetAllOperationsHandler>();
    
    // Application Services
    services.AddScoped<IOperationService, OperationService>();
}
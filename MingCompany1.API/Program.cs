using Microsoft.EntityFrameworkCore;
using MingCompany.Infrastructure.Data;
using MingCompany.Infrastructure.Repositories;
using MingCompany.Domain.Services;
using MingCompany.Domain.Entities;
using MingCompany.Application.Services;
using MingCompany.Application.Handlers;
using MingCompany.Application.Commands;
using MingCompany.Application.Queries;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});



// Database Configuration
builder.Services.AddDbContext<MiningDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de dependencias
RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MingCompany API v1");
        c.RoutePrefix = string.Empty; 
    });
}

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
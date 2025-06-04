using MingCompany.Application.Commands;
using MingCompany.Application.Queries;
using MingCompany.Domain.Entities;

namespace MingCompany.Application.Services
{
    public interface IOperationService
    {
        Task<Operation> ExecuteAsync(CreateOperationCommand command);
        Task<bool> ExecuteAsync(DeleteOperationCommand command);
        Task<List<Operation>> ExecuteAsync(GetAllOperationsQuery query);
    }
}
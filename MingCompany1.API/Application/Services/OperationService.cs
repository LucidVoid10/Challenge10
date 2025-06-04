using MingCompany.Application.Commands;
using MingCompany.Application.Handlers;
using MingCompany.Application.Queries;
using MingCompany.Domain.Entities;

namespace MingCompany.Application.Services
{
    public class OperationService : IOperationService
    {
        private readonly ICommandHandler<CreateOperationCommand, Operation> _createHandler;
        private readonly ICommandHandler<DeleteOperationCommand, bool> _deleteHandler;
        private readonly IQueryHandler<GetAllOperationsQuery, List<Operation>> _getAllHandler;

        public OperationService(
            ICommandHandler<CreateOperationCommand, Operation> createHandler,
            ICommandHandler<DeleteOperationCommand, bool> deleteHandler,
            IQueryHandler<GetAllOperationsQuery, List<Operation>> getAllHandler)
        {
            _createHandler = createHandler;
            _deleteHandler = deleteHandler;
            _getAllHandler = getAllHandler;
        }

        public async Task<Operation> ExecuteAsync(CreateOperationCommand command)
        {
            return await _createHandler.HandleAsync(command);
        }

        public async Task<bool> ExecuteAsync(DeleteOperationCommand command)
        {
            return await _deleteHandler.HandleAsync(command);
        }

        public async Task<List<Operation>> ExecuteAsync(GetAllOperationsQuery query)
        {
            return await _getAllHandler.HandleAsync(query);
        }
    }
}
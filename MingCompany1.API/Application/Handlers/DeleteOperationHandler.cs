using MingCompany.Application.Commands;
using MingCompany.Domain.Services;
using MingCompany.Infrastructure.Repositories;

namespace MingCompany.Application.Handlers
{
    public class DeleteOperationHandler : ICommandHandler<DeleteOperationCommand, bool>
    {
        private readonly IOperationRepository _repository;
        private readonly IOperationDomainService _domainService;

        public DeleteOperationHandler(IOperationRepository repository, IOperationDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<bool> HandleAsync(DeleteOperationCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), "El comando de eliminación no puede ser nulo.");

            var operation = await _repository.GetByIdAsync(command.Id);

            if (operation == null)
                throw new InvalidOperationException($"No se encontró la operación con ID {command.Id}");

            _domainService.ValidateOperationForDeletion(operation); 

            await _repository.DeleteAsync(operation);
            return true;
        }

    }
}
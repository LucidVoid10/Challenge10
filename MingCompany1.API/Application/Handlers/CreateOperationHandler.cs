﻿using MingCompany.Application.Commands;
using MingCompany.Domain.Entities;
using MingCompany.Domain.Services;
using MingCompany.Infrastructure.Repositories;

namespace MingCompany.Application.Handlers
{
    public class CreateOperationHandler : ICommandHandler<CreateOperationCommand, Operation>
    {
        private readonly IOperationRepository _repository;
        private readonly IOperationDomainService _domainService;

        public CreateOperationHandler(IOperationRepository repository, IOperationDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<Operation> HandleAsync(CreateOperationCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), "El comando de creación no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(command.Title))
                throw new ArgumentException("El título de la operación es obligatorio.", nameof(command.Title));

            var operation = new Operation
            {
                Title = command.Title,
                Type = command.Type,
                Date = command.Date,
                Status = command.Status
            };

            _domainService.ValidateOperationForCreation(operation); 

            return await _repository.AddAsync(operation);
        }

    }
}
using MingCompany.Domain.Entities;
using MingCompany.Domain.Exceptions;

namespace MingCompany.Domain.Services
{
    public class OperationDomainService : IOperationDomainService
    {
        public void ValidateOperationForCreation(Operation operation)
        {
            if (operation.Date > DateTime.Now)
            {
                throw new DomainException("No se pueden registrar operaciones con fecha futura.");
            }
        }

        public void ValidateOperationForDeletion(Operation operation)
        {
            var daysSinceCompletion = (DateTime.Now - operation.CompletedDate).Days;
            
            if (daysSinceCompletion <= 30)
            {
                throw new DomainException("Solo se pueden eliminar operaciones completadas hace más de 30 días.");
            }
        }
    }
}
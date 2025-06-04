using MingCompany.Domain.Entities;

namespace MingCompany.Domain.Services
{
    public interface IOperationDomainService
    {
        void ValidateOperationForCreation(Operation operation);
        void ValidateOperationForDeletion(Operation operation);
    }
}
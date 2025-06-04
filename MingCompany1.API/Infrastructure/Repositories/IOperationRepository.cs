using MingCompany.Domain.Entities;

namespace MingCompany.Infrastructure.Repositories
{
    public interface IOperationRepository
    {
        Task<Operation?> GetByIdAsync(int id);
        Task<List<Operation>> GetAllAsync();
        Task<Operation> AddAsync(Operation operation);
        Task DeleteAsync(Operation operation);
        Task SaveChangesAsync();
    }
}
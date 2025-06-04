using Microsoft.EntityFrameworkCore;
using MingCompany.Domain.Entities;
using MingCompany.Infrastructure.Data;

namespace MingCompany.Infrastructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly MiningDbContext _context;

        public OperationRepository(MiningDbContext context)
        {
            _context = context;
        }

        public async Task<Operation?> GetByIdAsync(int id)
        {
            return await _context.Operations.FindAsync(id);
        }

        public async Task<List<Operation>> GetAllAsync()
        {
            return await _context.Operations.ToListAsync();
        }

        public async Task<Operation> AddAsync(Operation operation)
        {
            operation.CompletedDate = DateTime.Now; // Asumimos que se completa al momento de crearse
            var result = await _context.Operations.AddAsync(operation);
            await SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(Operation operation)
        {
            _context.Operations.Remove(operation);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
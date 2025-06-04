using MingCompany.Application.Queries;
using MingCompany.Domain.Entities;
using MingCompany.Infrastructure.Repositories;

namespace MingCompany.Application.Handlers
{
    public class GetAllOperationsHandler : IQueryHandler<GetAllOperationsQuery, List<Operation>>
    {
        private readonly IOperationRepository _repository;

        public GetAllOperationsHandler(IOperationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Operation>> HandleAsync(GetAllOperationsQuery query)
        {
            return await _repository.GetAllAsync();
        }
    }
}
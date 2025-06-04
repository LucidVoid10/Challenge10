using MingCompany.Domain.Entities;

namespace MingCompany.Application.Commands
{
    public class CreateOperationCommand
    {
        public string Title { get; set; } = string.Empty;
        public OperationType Type { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; } = true;
    }
}
using System.ComponentModel.DataAnnotations;

namespace MingCompany.Domain.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        public OperationType Type { get; set; }
        
        public DateTime Date { get; set; }
        
        public bool Status { get; set; } = true; // true = activo, false = inactivo
        
        public DateTime CompletedDate { get; set; }
    }
}
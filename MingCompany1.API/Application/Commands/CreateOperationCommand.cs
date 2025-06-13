using MingCompany.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MingCompany.Application.Commands
{
    /// <summary>
    /// Comando para crear una nueva operación minera.
    /// </summary>
    public class CreateOperationCommand
    {
        /// <summary>
        /// Título de la operación.
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de operación (por ejemplo: Exploración, Extracción, etc.).
        /// </summary>
        [Required]
        public OperationType Type { get; set; }

        /// <summary>
        /// Fecha en que se realizará o realizó la operación.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Estado de la operación (activa o inactiva).
        /// </summary>
        public bool Status { get; set; } = true;
    }
}
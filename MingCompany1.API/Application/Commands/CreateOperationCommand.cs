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
        [Required(ErrorMessage = "El título es obligatorio.")]
        [MinLength(3, ErrorMessage = "El título debe tener al menos 3 caracteres.")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de operación (por ejemplo: Exploración, Extracción, etc.).
        /// </summary>
        [Required(ErrorMessage = "El tipo de operación es obligatorio.")]
        public OperationType Type { get; set; }

        /// <summary>
        /// Fecha en que se realizará o realizó la operación.
        /// </summary>
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Estado de la operación (activa o inactiva).
        /// </summary>
        public bool Status { get; set; } = true;
    }
}
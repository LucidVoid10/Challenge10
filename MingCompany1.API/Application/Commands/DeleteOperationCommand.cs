using System.ComponentModel.DataAnnotations;

namespace MingCompany.Application.Commands
{
    /// <summary>
    /// Comando para eliminar una operación por su ID.
    /// </summary>
    public class DeleteOperationCommand
    {
        /// <summary>
        /// Identificador único de la operación a eliminar.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "El ID debe ser mayor que cero.")]
        public int Id { get; set; }
    }
}
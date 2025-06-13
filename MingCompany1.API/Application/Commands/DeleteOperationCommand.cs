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
        public int Id { get; set; }
    }
}
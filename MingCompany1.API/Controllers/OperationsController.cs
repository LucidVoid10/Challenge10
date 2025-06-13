using Microsoft.AspNetCore.Mvc;
using MingCompany.Application.Services;
using MingCompany.Application.Commands;
using MingCompany.Application.Queries;
using MingCompany.Domain.Exceptions;

namespace MingCompany.Api.Controllers
{
    /// <summary>
    /// API para gestionar operaciones mineras.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        /// <summary>
        /// Obtiene todas las operaciones registradas.
        /// </summary>
        /// <returns>Lista de operaciones mineras</returns>
        /// <response code="200">Operaciones recuperadas exitosamente</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet]
        public async Task<IActionResult> GetAllOperations()
        {
            try
            {
                var query = new GetAllOperationsQuery();
                var operations = await _operationService.ExecuteAsync(query);
                return Ok(operations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Crea una nueva operación minera.
        /// </summary>
        /// <param name="command">Datos de la operación a crear</param>
        /// <returns>Operación creada</returns>
        /// <response code="201">Operación creada exitosamente</response>
        /// <response code="400">Error de validación o datos inválidos</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPost]
        public async Task<IActionResult> CreateOperation([FromBody] CreateOperationCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var createdOperation = await _operationService.ExecuteAsync(command);
                return Created($"/api/operations/{createdOperation.Id}", createdOperation);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (DomainException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina una operación minera por ID.
        /// </summary>
        /// <param name="id">ID de la operación a eliminar</param>
        /// <returns>Sin contenido si fue eliminada, o error si no se encontró</returns>
        /// <response code="204">Operación eliminada exitosamente</response>
        /// <response code="404">No se encontró la operación</response>
        /// <response code="400">Error de dominio en la eliminación</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperation(int id)
        {
            try
            {
                var command = new DeleteOperationCommand { Id = id };
                var result = await _operationService.ExecuteAsync(command);
                
                if (!result)
                    return NotFound("Operación no encontrada");

                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}

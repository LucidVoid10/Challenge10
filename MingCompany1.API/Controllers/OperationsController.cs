using Microsoft.AspNetCore.Mvc;
using MingCompany.Application.Services;
using MingCompany.Application.Commands;
using MingCompany.Application.Queries;
using MingCompany.Domain.Exceptions;

namespace MingCompany.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

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
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

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
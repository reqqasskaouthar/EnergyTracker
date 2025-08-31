using EnergyTracker.Application.Commands.Consumption;
using EnergyTracker.Application.Commands.User;
using EnergyTracker.Application.Common.Exceptions;
using EnergyTracker.Application.Queries.Consumption;
using EnergyTracker.Application.Queries.Exporter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumptionController : Controller
    {
        private readonly IMediator _mediator;

        public ConsumptionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Createconsumption command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consumptions = await _mediator.Send(new GetAllConsumptions());
            return Ok(consumptions);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumption(Guid id)
        {
            try
            {
                var command = new DeleteConsumption(id);
                await _mediator.Send(command);
                return NoContent(); 
            }
            catch (NotFoundException)
            {
                return NotFound(); 
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var consumption = await _mediator.Send(new GetConsumptionById(id));
            if (consumption == null)
                return NotFound();

            return Ok(consumption);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConsumption(Guid id, [FromBody] UpdateConsumptionCommand command)
        {
            if (id != command.ConsumptionId)
                return BadRequest("L'ID dans l'URL ne correspond pas à l'ID dans le corps de la requête.");

            try
            {
                await _mediator.Send(command);
                return NoContent(); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur serveur: {ex.Message}");
            }
        }
        [HttpGet("export")]
        public async Task<IActionResult> ExportConsumptions()
        {
            var fileContent = await _mediator.Send(new ExportConsumptions());
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Consumptions.xlsx");
        }
    }

}

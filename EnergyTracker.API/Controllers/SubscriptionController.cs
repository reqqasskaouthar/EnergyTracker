using EnergyTracker.Application.Commands.Consumption;
using EnergyTracker.Application.Commands.Subscription;
using EnergyTracker.Application.Common.Exceptions;
using EnergyTracker.Application.Queries.Consumption;
using EnergyTracker.Application.Queries.Exporter;
using EnergyTracker.Application.Queries.Subscription;
using EnergyTracker.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubscription command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subscription = await _mediator.Send(new GetSubscriptionById(id));
            if (subscription == null)
                return NotFound();

            return Ok(subscription);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(Guid id)
        {
            try
            {
                var command = new DeleteSubscription(id);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscription = await _mediator.Send(new GetAllSubscription());
            return Ok(subscription);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscription(Guid id, [FromBody] Updatesubscription command)
        {
            if (id != command.SubscriptionId)
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
        
    }
}


using EnergyTracker.Application.Commands.User;
using EnergyTracker.Application.Common.Exceptions;
using EnergyTracker.Application.DTOs;
using EnergyTracker.Application.Queries.Exporter;
using EnergyTracker.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(new { UserId = userId });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsers());
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var command = new DeleteUser(id);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.UserId)
                return BadRequest();

            var command = new UpdateUser(id, updateUserDto.FirstName, updateUserDto.LastName, updateUserDto.Email);
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        [HttpGet("export")]
        public async Task<IActionResult> ExportUsersToExcel(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ExportUsers(), cancellationToken);

            return File(result,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Users.xlsx");
        }
        

    }
}

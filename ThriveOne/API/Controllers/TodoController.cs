using Application.Features.Todos.Create;
using Application.Features.Todos.Read;
using Application.Features.Todos.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class TodoController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await mediator.Send(new ReadTodos());
            if (result == null)
            {
                return NotFound("No todos found.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var result = await mediator.Send(new ReadTodo(id));

            if (result == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodo command)
    {
        try
        {
            var result = await mediator.Send(command);

            if (result == Guid.Empty)
            {
                return BadRequest("Failed to create todo.");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodo command)
    {
        try
        {
            if (id != command.Id)
            {
                return BadRequest("Todo Id mismatch.");
            }
            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

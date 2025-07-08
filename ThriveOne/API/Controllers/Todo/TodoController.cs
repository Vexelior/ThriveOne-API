using Application.Features.Todo.Create;
using Application.Features.Todo.Delete;
using Application.Features.Todo.Read;
using Application.Features.Todo.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Todo;

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
            return Ok(await mediator.Send(new ReadTodos()));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
        }
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            return Ok(await mediator.Send(new ReadTodo(id)));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodo command)
    {
        try
        {
            return Ok(await mediator.Send(command));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
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
            return Ok(await mediator.Send(command));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            return Ok(await mediator.Send(new DeleteTodo(id)));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
        }
    }
}

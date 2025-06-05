using Application.Features.WorkTask.Create;
using Application.Features.WorkTask.Delete;
using Application.Features.WorkTask.Read;
using Application.Features.WorkTask.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.WorkTask;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class WorkTaskController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new ReadWorkTasks());
        if (result == null || !result.Any())
        {
            return NotFound("No work tasks found.");
        }
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new ReadWorkTask(id));
        if (result == null)
        {
            return NotFound($"Work task with ID {id} not found.");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorkTask createWorkTask)
    {
        var result = await mediator.Send(createWorkTask);
        if (result == null)
        {
            return BadRequest("Failed to create work task.");
        }
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWorkTask updateWorkTask)
    {
        if (id != updateWorkTask.Id)
        {
            return BadRequest("ID in the URL does not match ID in the request body.");
        }
        var result = await mediator.Send(updateWorkTask);
        if (result == null)
        {
            return NotFound($"Work task with ID {id} not found.");
        }
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteWorkTask(id));
        if (result == null)
        {
            return NotFound($"Work task with ID {id} not found.");
        }
        return Ok(result);
    }
}

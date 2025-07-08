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
        try
        {
            return Ok(await mediator.Send(new ReadWorkTasks()));
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
            return Ok(await mediator.Send(new ReadWorkTask(id)));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorkTask createWorkTask)
    {
        try
        {
            return Ok(await mediator.Send(createWorkTask));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWorkTask updateWorkTask)
    {
        try
        {
            if (id != updateWorkTask.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }
            return Ok(await mediator.Send(updateWorkTask));
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
            return Ok(await mediator.Send(new DeleteWorkTask(id)));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
        }
    }
}

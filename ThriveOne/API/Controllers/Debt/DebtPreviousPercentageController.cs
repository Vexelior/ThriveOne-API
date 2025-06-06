using Application.Features.Debt.Create.PreviousPercentage;
using Application.Features.Debt.Delete.PreviousPercentage;
using Application.Features.Debt.Read.PreviousPercentage;
using Application.Features.Debt.Update.PreviousPercentage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtPreviousPercentageController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await mediator.Send(new ReadDebtPreviousPercentages());
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
            var result = await mediator.Send(new ReadDebtPreviousPercentage(id));
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDebtPreviousPercentage command)
    {
        try
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDebtPreviousPercentage command)
    {
        try
        {
            if (id != command.Id)
            {
                return BadRequest("ID in the URL does not match the ID in the request body.");
            }
            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var command = new DeleteDebtPreviousPercentage(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

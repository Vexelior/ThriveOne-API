using Application.Features.Debt.Create.Debt;
using Application.Features.Debt.Read.Debt;
using Application.Features.Debt.Update.Debt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await mediator.Send(new ReadDebts());
            if (result == null || !result.Any())
            {
                return NotFound("No debts found.");
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
            var result = await mediator.Send(new ReadDebt(id));
            if (result == null)
            {
                return NotFound($"Debt with ID {id} not found.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDebt command)
    {
        try
        {
            var result = await mediator.Send(command);

            if (result == null)
            {
                return NotFound("Failed to create debt.");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDebt command)
    {
        try
        {
            if (id != command.Id)
            {
                return BadRequest("Debt ID mismatch.");
            }
            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound($"Debt with ID {id} not found.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

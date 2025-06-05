using Application.Features.Debt.Create.PreviousAmount;
using Application.Features.Debt.Delete.PreviousAmount;
using Application.Features.Debt.Read.PreviousAmount;
using Application.Features.Debt.Update.PreviousAmount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtPreviousAmountController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await mediator.Send(new ReadDebtPreviousAmounts());
            if (result == null || !result.Any())
            {
                return NotFound("No debt payments found.");
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
            var result = await mediator.Send(new ReadDebtPreviousAmount(id));
            if (result == null)
            {
                return NotFound("No debt payments found.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDebtPreviousAmount command)
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
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDebtPreviousAmount command)
    {
        try
        {
            if (id != command.Id)
            {
                return BadRequest("ID in the URL does not match the ID in the request body.");
            }
            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound("Failed to update debt previous amount.");
            }
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
            var result = await mediator.Send(new DeleteDebtPreviousAmount(id));
            if (result == null)
            {
                return NotFound("Failed to delete debt previous amount.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

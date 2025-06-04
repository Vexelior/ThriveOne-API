using Application.Features.Debt.Create.PreviousAmount;
using Application.Features.Debt.Read.PreviousAmount;
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
}

using Application.Features.Debt.Create.History;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtHistoryController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await mediator.Send(new Application.Features.Debt.Read.History.ReadDebtHistories());
            if (result == null || !result.Any())
            {
                return NotFound("No debt history found.");
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
            var result = await mediator.Send(new Application.Features.Debt.Read.History.ReadDebtHistory(id));
            if (result == null)
            {
                return NotFound("Debt history not found.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDebtHistory command)
    {
        try
        {
            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound("Failed to create debt image.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

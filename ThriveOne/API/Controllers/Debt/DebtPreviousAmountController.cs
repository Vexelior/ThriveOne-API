using Application.Features.Debt.Create.PreviousAmount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtPreviousAmountController(IMediator mediator) : ControllerBase
{
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

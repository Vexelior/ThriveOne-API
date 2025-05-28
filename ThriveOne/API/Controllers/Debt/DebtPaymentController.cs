using Application.Features.Debt.Create.Payment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtPaymentController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDebtPayment command)
    {
        try
        {
            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound("Failed to create debt payment.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

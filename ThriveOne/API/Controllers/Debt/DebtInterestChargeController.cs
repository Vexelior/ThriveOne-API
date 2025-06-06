using Application.Features.Debt.Create.InterestCharge;
using Application.Features.Debt.Delete.InterestCharge;
using Application.Features.Debt.Read.InterestCharge;
using Application.Features.Debt.Update.InterestCharge;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtInterestChargeController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await mediator.Send(new ReadDebtInterestCharges());
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
            var result = await mediator.Send(new ReadDebtInterestCharge(id));
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDebtInterestCharge command)
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
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDebtInterestCharge command)
    {
        try
        {
            if (id != command.Id)
            {
                return BadRequest("ID in the URL does not match ID in the body.");
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
            var result = await mediator.Send(new DeleteDebtInterestCharge(id));
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

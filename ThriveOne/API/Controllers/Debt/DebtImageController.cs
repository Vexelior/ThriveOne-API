using Application.Features.Debt.Create.Image;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtImageController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDebtImage command)
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

using Application.Features.Debt.Create.Image;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Debt;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class DebtImageController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await mediator.Send(new Application.Features.Debt.Read.Image.ReadDebtImages());
            if (result == null || !result.Any())
            {
                return NotFound("No debt images found.");
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
            var result = await mediator.Send(new Application.Features.Debt.Read.Image.ReadDebtImage(id));
            if (result == null)
            {
                return NotFound($"Debt image with ID {id} not found.");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

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

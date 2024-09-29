using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTécnica.Application.Motions.CreateMotion;
using PruebaTécnica.Application.Motions.DeleteMotion;
using PruebaTécnica.Application.Motions.GetMotion;
using PruebaTécnica.Application.Motions.GetMotions;
using PruebaTécnica.Application.Motions.UpdateMotion;
using PruebaTécnica.Application.Persons.CreatePerson;
using PruebaTécnica.Application.Persons.UpdatePerson;
using PruebaTécnica.Domain.DTOs.Motion;
using PruebaTécnica.Domain.DTOs.Person;

namespace PruebaTecnica.ApiView.Controllers.Motion;

[ApiController]
[Route("api/[controller]")]
public class MotionController : ControllerBase
{
    private readonly ISender _sender;

    public MotionController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetMotions")]
    public async Task<IActionResult> GetMotions(CancellationToken cancellationToken)
    {
        var command = new GetMotionsCommands();

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpGet("GetMotion/{id}")]
    public async Task<IActionResult> GetMotion(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetMotionCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost("CreateMotion")]
    public async Task<IActionResult> CreatePerson([FromBody] MotionDTO2 dto)
    {
        var command = new CreateMotionCommand(dto);

        var result = await _sender.Send(command);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPut("UpdateMotion/{id}")]
    public async Task<IActionResult> UpdateMotion([FromBody] UpdateMotionCommand dto)
    {
        var result = await _sender.Send(dto);

        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return NotFound(result.Error?.Name ?? "Person not found");
    }

    [HttpDelete("DeleteMotion/{id}")]
    public async Task<IActionResult> DeleteMotion(Guid id)
    {
        var result = await _sender.Send(new DeleteMotionCommand(id));

        if (result)
        {
            return NoContent();
        }
        return Ok("true");
    }
}

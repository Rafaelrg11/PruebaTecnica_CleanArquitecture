using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PruebaTécnica.Application.Persons.CreatePerson;
using PruebaTécnica.Application.Persons.DeletePerson;
using PruebaTécnica.Application.Persons.GetPerson;
using PruebaTécnica.Application.Persons.GetPersons;
using PruebaTécnica.Application.Persons.UpdatePerson;
using PruebaTécnica.Domain.DTOs.Person;
using PruebaTécnica.Domain.Persons;


namespace PruebaTecnica.ApiView.Controllers.Person;

[ApiController]
[Route("api/persons")]
public class PersonController : ControllerBase
{
    private readonly ISender _sender;
        
    public PersonController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetPersons")]
    public async Task<IActionResult> GetPersons()
    {
        var command = new GetAccountsCommand();

        var result = await _sender.Send(command);

        return Ok(result);
    }

    [HttpGet("GetPerson/{id}")]
    public async Task<IActionResult> GetPerson(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetAccountCommand(id);

        var result = await _sender.Send(command);

        return Ok(result);
    }

    [HttpPost("CreatePerson")]
    public async Task<IActionResult> CreatePerson([FromBody] PersonDTO dto)
    {
        var command = new CreatePersonCommand(dto);

        var result = await _sender.Send(command);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return NotFound(result.Error?.Name ?? "Person not found");
    }

    [HttpPut("UpdatePerson/{id}")]
    public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand dto)
    {
        var result = await _sender.Send(dto);

        if (result.IsSuccess) 
        {
            return Ok(result);
        }
        return NotFound(result.Error?.Name ?? "Person not found");
    }

    [HttpDelete("DeletePerson/{id}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        var result = await _sender.Send(new DeleteAccountCommand(id));
        if (result)
        {
            return NoContent();
        }

        return Ok("true");
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTécnica.Application.Clients;
using PruebaTécnica.Application.Clients.CreateClient;
using PruebaTécnica.Application.Clients.DeleteClient;
using PruebaTécnica.Application.Clients.GetAccountState;
using PruebaTécnica.Application.Clients.GetClient;
using PruebaTécnica.Application.Clients.GetClients;
using PruebaTécnica.Application.Clients.NewFolder;
using PruebaTécnica.Application.Helpers;
using PruebaTécnica.Application.Persons.CreatePerson;
using PruebaTécnica.Application.Persons.DeletePerson;
using PruebaTécnica.Domain.DTOs.Client;
using PruebaTécnica.Domain.DTOs.Person;
using System.Dynamic;

namespace PruebaTecnica.ApiView.Controllers.Client;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private readonly ISender _sender;

    public ClientController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetClients")]
    public async Task<IActionResult> GetClients()
    {
        var query = new GetMotionsCommands();

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpGet("GetClient/{id}")]
     public async Task<IActionResult> GetClient(Guid id, CancellationToken cancellationToken)
     {
         var query = new GetClientCommand(id);

         var result = await _sender.Send(query, cancellationToken);

         return result.IsSuccess ? Ok(result.Value) : NotFound();
     }

    [HttpPost("CreateClient")]
    public async Task<IActionResult> CreatePerson([FromBody] ClientDTO2 dto)
    {
        var command = new CreateClientCommand( dto.PersonaId, dto.Contraseña, dto.Estado);

        var result = await _sender.Send(command);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPut("UpdateClient/{id}")]
    public async Task<IActionResult> UpdateClient(UpdateClientCommand updateClient, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(updateClient, cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return NotFound(result.Error?.Name ?? "Person not found");
    }

    [HttpDelete("DeleteClient/{id}")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        var result = await _sender.Send(new DeleteClientCommand(id));
        if (result)
        {
            return NoContent();
        }

        return Ok("true");
    }

    [HttpGet("GetAccountStatus/{guid}")]

    public async Task<IActionResult> GetAccountState(Guid guid)
    {
        var command = new AccountStateCommand(guid);
        var result = await _sender.Send(command);

        dynamic respuesta = new ExpandoObject();
        respuesta.Cuentas = result.Value.Cuentas;
        respuesta.Movimientos = result.Value.Movimientos;

        string csv = CSV.ConvertToCsv(respuesta.Cuentas, respuesta.Movimientos);

        if (result.IsSuccess)
        {
            return Ok(csv);
        }
        else
        {
            return BadRequest(result.Error);
        }
    }
}

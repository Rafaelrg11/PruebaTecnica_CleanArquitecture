using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTécnica.Application.Account.CreateAccount;
using PruebaTécnica.Application.Account.DeleteAccount;
using PruebaTécnica.Application.Account.GetAccount;
using PruebaTécnica.Application.Account.GetAccounts;
using PruebaTécnica.Application.Account.UpdateAccount;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Account;

namespace PruebaTecnica.ApiView.Controllers.Account;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ISender _sender;

    public AccountController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("GetAccounts")]
    public async Task<IActionResult> GetAccounts(CancellationToken cancellationToken)
    {
        var query = new GetAccountsCommand();

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound();
    }

    [HttpGet("GetAccount/{id}")]
    public async Task<IActionResult> GetAccount(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetAccountCommand(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost("CreateAccount")]
    public async Task<IActionResult> CreatePerson([FromBody] AccountDTO dto)
    {
        var command = new CreateAccountCommand(dto.IdCuenta, dto.IdCliente, dto.NumeroCuenta,
            dto.Saldo, dto.Estado, dto.TipoDeCuenta);

        var result = await _sender.Send(command);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPut("UpdateAccount/{id}")]
    public async Task<IActionResult> UpdateAccount(UpdateAccountCommand command)
    {
        var sender = await _sender.Send(command);

        if (sender.IsSuccess)
        {
            return Ok(sender);
        }
        return NotFound(sender.Error?.Name ?? "Person not found");
    }

    [HttpDelete("DeleteAccount/{id}")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        var result = await _sender.Send(new DeleteAccountCommand(id));
        if (result)
        {
            return NoContent();
        }

        return Ok(true);
    }

}

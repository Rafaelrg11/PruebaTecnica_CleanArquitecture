using MediatR;
using PruebaTécnica.Application.Persons.UpdatePerson;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Result>
{
    private readonly IAccountRepository _personaRepository;

    public UpdateAccountCommandHandler(IAccountRepository personaRepository)
    {
        _personaRepository = personaRepository;
    }

    async Task<Result> IRequestHandler<UpdateAccountCommand, Result>.Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var persona = await _personaRepository.GetCuenta2(request.IdAccount, cancellationToken );

        if (persona == null)
        {
        }

        persona.NumeroCuenta = request.NumeroCuenta;
        persona.TipoDeCuenta = request.TipoDeCuenta;
        persona.IdCliente = request.IdCliente;
        persona.Estado = request.Estado;
        persona.Saldo = request.Saldo;

        await _personaRepository.UpdateCuenta(persona);

        return Result.Success();
    }
}

using MediatR;
using PruebaTécnica.Application.Helpers;
using PruebaTécnica.Application.Persons.GetPerson;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace PruebaTécnica.Application.Clients.GetAccountState;

public class AccountStateCommandHandler : IRequestHandler<AccountStateCommand, Result<(IEnumerable<PruebaTécnica.Domain.Cuenta.Account> Cuentas, IEnumerable<Motion> Movimientos)>>
{
    private readonly IClientRepository _personaRepository;
    public AccountStateCommandHandler(IClientRepository personRepository)
    {
        _personaRepository = personRepository;
    }

    Task<Result<(IEnumerable<Domain.Cuenta.Account> Cuentas, IEnumerable<Motion> Movimientos)>> IRequestHandler<AccountStateCommand, Result<(IEnumerable<Domain.Cuenta.Account> Cuentas, IEnumerable<Motion> Movimientos)>>.Handle(AccountStateCommand request, CancellationToken cancellationToken)
    {
         var result = _personaRepository.ObtenerCuentasYMovimientos(request.Guid);

        return Task.FromResult(Result<(IEnumerable<Domain.Cuenta.Account> Cuentas, IEnumerable<Motion> Movimientos)>.Success(result));
       
    }
}

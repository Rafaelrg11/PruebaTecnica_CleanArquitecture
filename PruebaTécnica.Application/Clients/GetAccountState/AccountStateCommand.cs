using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.GetAccountState;

public sealed class AccountStateCommand : IRequest<Result<(IEnumerable<PruebaTécnica.Domain.Cuenta.Account> Cuentas, IEnumerable<Motion> Movimientos)>>
{
    public Guid Guid { get; }

    public AccountStateCommand(Guid guid)
    {
        Guid = guid;
    }
}

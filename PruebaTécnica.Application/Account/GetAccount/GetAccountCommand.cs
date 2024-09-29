using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.GetAccount;

public sealed class GetAccountCommand : IRequest<Result<AccountDTO>>
{
    public Guid Guid { get; }

    public GetAccountCommand(Guid guid)
    {
        Guid = guid;
    }
}

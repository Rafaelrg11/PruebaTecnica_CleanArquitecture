using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.DeleteAccount;

public sealed class DeleteAccountCommand : IRequest<bool>
{
    public Guid Guid { get; }

    public DeleteAccountCommand(Guid guid)
    {
        Guid = guid;
    }

}

using MediatR;
using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.DeleteClient;

public sealed class DeleteClientCommand : IRequest<bool>
{
    public Guid Guid { get; }

    public DeleteClientCommand(Guid guid)
    {
        Guid = guid;
    }
}

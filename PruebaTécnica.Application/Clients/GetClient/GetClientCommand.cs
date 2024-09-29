using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.GetClient;

public sealed class GetClientCommand : IRequest<Result<ClientDTO>>
{
    public Guid Guid { get; }

    public GetClientCommand(Guid guid)
    {
        Guid = guid;
    }
}

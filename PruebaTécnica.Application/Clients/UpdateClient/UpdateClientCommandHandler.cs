using MediatR;
using PruebaTécnica.Application.Clients.NewFolder;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.DTOs.Client;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.UpdateClient;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Result>
{
    private readonly IClientRepository _clientRepository;

    public UpdateClientCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    async Task<Result> IRequestHandler<UpdateClientCommand, Result>.Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetClient(request.IdCliente);

        if (client == null)
        {
        }

        client.UpdatePassword(new Password(request.Contraseña));
        client.UpdateState(new State(request.Estado));

        await _clientRepository.UpdateCliente(client);

        return Result.Success();
    }
}

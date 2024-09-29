using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.DTOs.Client;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.GetClient;

public class GetClientCommandGandler : IRequestHandler<GetClientCommand, Result<ClientDTO>>
{
    private readonly IClientRepository clientRepository;

    public GetClientCommandGandler(IClientRepository clientRepository)
    {
        this.clientRepository = clientRepository;
    }

    public async Task<Result<ClientDTO>> Handle(GetClientCommand request, CancellationToken cancellationToken)
    {
        var result = await clientRepository.GetCliente(request.Guid);

        return result;
    }
}

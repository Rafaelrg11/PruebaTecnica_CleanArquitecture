using MediatR;
using PruebaTécnica.Application.Persons.GetPersons;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.GetClients;

public class GetClientsCommandHandler : IRequestHandler<GetMotionsCommands, Result>
{
    private readonly IClientRepository _clientRepository;
    public GetClientsCommandHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public async Task<Result> Handle(GetMotionsCommands request, CancellationToken cancellationToken)
    {
        var clients = await _clientRepository.GetClientes();

        return Result.Success(clients);
    }
}

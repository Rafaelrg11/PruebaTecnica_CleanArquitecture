using MediatR;
using PruebaTécnica.Application.Persons.DeletePerson;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.DeleteClient;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, bool>
{
    private readonly IClientRepository _clientRepository;

    public DeleteClientCommandHandler(IClientRepository personaRepository)
    {
        _clientRepository = personaRepository;
    }

    async Task<bool> IRequestHandler<DeleteClientCommand, bool>.Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var person = await _clientRepository.GetClient(request.Guid);

        if (person == null)
        {
            return false; // No se encontró la persona
        }

        _clientRepository.DeleteCliente(person);

        return true;
    }

}

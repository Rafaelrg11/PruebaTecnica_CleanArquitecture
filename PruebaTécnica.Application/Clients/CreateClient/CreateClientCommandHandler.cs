using MediatR;
using PruebaTécnica.Application.Persons.CreatePerson;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.CreateClient;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientRepository _clienteRespository;

    public CreateClientCommandHandler(IUnitOfWork unitOfWork, IClientRepository clienteRespository)
    {
        _unitOfWork = unitOfWork;
        _clienteRespository = clienteRespository;
    }

    public async Task<Result<Guid>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
     {

        var password = new Password(request.Contraseña);
        var estado = new State(request.Estado);

        var client = Client.Create(password, estado, request.PersonaId);
        
        _clienteRespository.CreateCliente(client);

         return Result.Success(client.IdCliente);
     }
}

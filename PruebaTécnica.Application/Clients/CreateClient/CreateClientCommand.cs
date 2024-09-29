using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.CreateClient;

public sealed class CreateClientCommand : IRequest<Result<Guid>>
{
    public Guid PersonaId { get; set; }
    public string Contraseña { get; set; }
    public bool Estado { get; set; }

    public CreateClientCommand(Guid personaId, string contraseña, bool estado)
    {
        PersonaId = personaId;
        Contraseña = contraseña;
        Estado = estado;
    }
}


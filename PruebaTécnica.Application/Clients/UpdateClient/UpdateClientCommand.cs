using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Account;
using PruebaTécnica.Domain.DTOs.Client;
using PruebaTécnica.Domain.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Clients.NewFolder;

public sealed class UpdateClientCommand : IRequest<Result>
{
    public Guid IdCliente { get; set; }
    public Guid PersonaId { get; set; }
    public string Contraseña { get; set; }
    public bool Estado { get; set; }

    public UpdateClientCommand(Guid idCliente, Guid personaId, string contraseña, bool estado)
    {
        IdCliente = idCliente;
        PersonaId = personaId;
        Contraseña = contraseña;
        Estado = estado;
    }
}

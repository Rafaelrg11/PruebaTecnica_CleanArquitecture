using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes.Events;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Personas.Events;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Clientes;

public class Client : Entity
{
    public Client(
        Guid id,
        Password password,
        State state)
        : base(id) 
    {
        Contraseña = password;
        Estado = state;
    }

    private Client() 
    {
    }
    public Guid IdCliente { get; private set; }
    public Password Contraseña {  get; private set; }
    public State Estado { get; private set; }
    public Guid PersonaId { get; private set; }
    public Person? Persona { get; private set; }
    public ICollection<Account> Accounts { get; private set; } = new List<Account>();

    public static Client Create(Password contraseña, State estado, Guid personaId)
    {
        var cliente = new Client(Guid.NewGuid(), contraseña, estado)
        {
            PersonaId = personaId
        };

        cliente.RaiseDomainEvent(new ClienteCreatedDomainEvent(cliente.Id));

        return cliente;
    }

    public void UpdatePassword(Password password)
    {
        Contraseña = password;
    }

    public void UpdateState(State state)
    {
        Estado = state;
    }

}

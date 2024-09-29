using Microsoft.EntityFrameworkCore;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.DTOs.Client;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Repository;

internal sealed class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext context) 
        : base(context)
    {
    }

    public void CreateCliente(Client cliente)
    {
        _context.Add(cliente);
        _context.SaveChanges();
    }

    public void DeleteCliente(Client client)
    {
        _context.Remove(client);
        _context.SaveChanges();
    }

    public async Task<Client> GetClient(Guid id)
    {
        var client = await _context.Clients
               .Include(c => c.Persona)
               .Include(c => c.Accounts)
               .FirstOrDefaultAsync(e => e.IdCliente == id);

        if (client == null)
        {
            return null;
        }

        await _context.Entry(client)
            .Reference(c => c.Persona)
            .LoadAsync();

        await _context.Entry(client)
            .Collection(c => c.Accounts)
            .LoadAsync();


        return client;
    }

    public (IEnumerable<Account> Cuentas, IEnumerable<Motion> Movimientos) ObtenerCuentasYMovimientos(Guid clienteId)
    {
        var cuentas = _context.Accounts
                        .Where(c => c.IdCliente == clienteId)
                        .ToList();

        var movimientos = _context.Motions
            .Where(m => cuentas.Select(c => c.IdCuenta).Contains(m.CuentaId))
            .ToList();

        return (cuentas, movimientos);
    }

    async Task<ClientDTO> IClientRepository.GetCliente(Guid id)
    {
        var result = await _context.Clients
        .Include(c => c.Persona)
        .Include(c => c.Accounts)
        .FirstOrDefaultAsync(e => e.IdCliente == id);

        if (result is null)
        {
            return null;
        }

        var client = new ClientDTO
        {
            IdCliente = result.IdCliente,
            PersonaId = result.PersonaId,
            Contraseña = result.Contraseña.Value,
            Estado = result.Estado.Value,
            person = new Domain.DTOs.Person.PersonDTO
            {
                Name = new Domain.DTOs.Person.NameDTO(result.Persona.Name.value),
                Genero = new Domain.DTOs.Person.GenrerDTO(result.Persona.Genero.Value),
                Edad = result.Persona.Edad.Value,
                Identificacion = new Domain.DTOs.Person.IdentificationDTO(result.Persona.Identificacion.Value),
                Dirección = new Domain.DTOs.Person.AddressDTO(result.Persona.Dirección.Value),
                Teléfono = result.Persona.Teléfono.Value,
                IdPersona = result.PersonaId
            },
            Accounts = result.Accounts.Select(e => new Domain.DTOs.Account.AccountDTO
            {
                IdCuenta = e.IdCuenta,
                IdCliente = e.IdCliente,
                TipoDeCuenta = e.TipoDeCuenta.Value,
                NumeroCuenta = e.NumeroCuenta.Value,
                Saldo = e.Saldo.Amount,
                Estado = e.Estado.status
            }).ToList()
        };

        return client;
    }

    async Task<IEnumerable<ClientDTO>> IClientRepository.GetClientes()
    {
        var result = await _context.Clients
            .Select(e => new ClientDTO
            {
                IdCliente = e.IdCliente,
                PersonaId = e.PersonaId,
                Contraseña = e.Contraseña.Value,
                Estado = e.Estado.Value,
                person = new Domain.DTOs.Person.PersonDTO
                {
                    Name = new Domain.DTOs.Person.NameDTO(e.Persona.Name.value),
                    Genero = new Domain.DTOs.Person.GenrerDTO(e.Persona.Genero.Value),
                    Edad = e.Persona.Edad.Value,
                    Identificacion = new Domain.DTOs.Person.IdentificationDTO(e.Persona.Identificacion.Value),
                    Dirección = new Domain.DTOs.Person.AddressDTO(e.Persona.Dirección.Value),
                    Teléfono = e.Persona.Teléfono.Value,
                    IdPersona = e.PersonaId
                },
                Accounts = e.Accounts.Select(e => new Domain.DTOs.Account.AccountDTO
                {
                    IdCuenta = e.IdCuenta,
                    IdCliente = e.IdCliente,
                    TipoDeCuenta = e.TipoDeCuenta.Value,
                    NumeroCuenta = e.NumeroCuenta.Value,
                    Saldo = e.Saldo.Amount,
                    Estado = e.Estado.status
                }).ToList()                
            }).ToListAsync();

        return result;
    }

    async Task IClientRepository.UpdateCliente(Client cliente)
    {
        _context.Clients.Update(cliente);

        _context.SaveChanges();
    }
}

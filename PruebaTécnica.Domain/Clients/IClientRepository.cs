using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.DTOs.Client;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Clientes;

public interface IClientRepository
{
    Task<IEnumerable<ClientDTO>> GetClientes();
    (IEnumerable<Account> Cuentas, IEnumerable<Motion> Movimientos) ObtenerCuentasYMovimientos
        (Guid clienteId);
    Task<ClientDTO> GetCliente(Guid id);
    Task<Client> GetClient(Guid id);
    void CreateCliente(Client cliente);
    Task UpdateCliente(Client cliente);
    void DeleteCliente(Client client);
}

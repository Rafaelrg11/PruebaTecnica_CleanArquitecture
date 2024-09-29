using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Movimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Clients;

public interface ClientInterface
{
    IEnumerable<Client> GetClientes();
    (IEnumerable<Account> Cuentas, IEnumerable<Motion> Movimientos) ObtenerCuentasYMovimientos
        (Guid clienteId);
    IEnumerable<Client> GetCliente(Guid id);
    public Client CreateCliente(Client cliente);
    void UpdateCliente(int idCliente, Client cliente);
    void DeleteCliente(int id);
}

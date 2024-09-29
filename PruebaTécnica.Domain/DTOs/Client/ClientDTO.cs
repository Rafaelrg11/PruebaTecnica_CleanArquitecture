using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.DTOs.Account;
using PruebaTécnica.Domain.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.DTOs.Client;

public sealed class ClientDTO
{
    public Guid IdCliente { get; set; }
    public Guid PersonaId { get; set; }
    public string Contraseña { get; set; }
    public bool Estado { get; set; }
    public PersonDTO person { get; set; }
    public ICollection<AccountDTO> Accounts { get; set; } = new List<AccountDTO>();
}

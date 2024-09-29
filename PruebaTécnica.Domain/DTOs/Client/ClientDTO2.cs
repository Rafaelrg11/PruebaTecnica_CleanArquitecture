using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.DTOs.Client;

public sealed class ClientDTO2
{
    public Guid IdCliente { get; set; }
    public Guid PersonaId { get; set; }
    public string Contraseña { get; set; }
    public bool Estado { get; set; }
}

using PruebaTécnica.Domain.Accounts;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.DTOs.Client;
using PruebaTécnica.Domain.DTOs.Motion;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.DTOs.Account;

public sealed class AccountDTO
{
    public Guid IdCuenta { get;  set; }
    public Guid IdCliente { get;  set; }
    public int NumeroCuenta { get;  set; }
    public decimal Saldo { get;  set; }
    public bool Estado { get;  set; }
    public string TipoDeCuenta { get;  set; }
    public ClientDTO2 Cliente { get; set; }
    public ICollection<MotionDTO2> movimientos { get; set; } = new List<MotionDTO2>();
}

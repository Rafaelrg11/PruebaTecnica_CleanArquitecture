using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.DTOs.Account;

public sealed class AccountDTO2
{
    public Guid IdCuenta { get; set; }
    public Guid IdCliente { get; set; }
    public int NumeroCuenta { get; set; }
    public decimal Saldo { get; set; }
    public bool Estado { get; set; }
    public string TipoDeCuenta { get; set; }
}

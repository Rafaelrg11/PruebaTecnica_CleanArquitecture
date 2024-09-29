using MediatR;
using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.UpdateAccount;

public sealed class UpdateAccountCommand : IRequest<Result>
{
    public Guid IdAccount { get; set; }
    public Guid IdCliente { get; set; }
    public int NumeroCuenta { get; set; }
    public decimal Saldo { get; set; }
    public bool Estado { get; set; }
    public string TipoDeCuenta { get; set; }

    public UpdateAccountCommand(Guid idCliente, int numeroCuenta, decimal saldo, bool estado, string tipoDeCuenta)
    {
        IdCliente = idCliente;
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
        Estado = estado;
        TipoDeCuenta = tipoDeCuenta;
    }
}

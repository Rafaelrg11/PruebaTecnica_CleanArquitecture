using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Account;
using PruebaTécnica.Domain.DTOs.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.CreateAccount;

public sealed class CreateAccountCommand : IRequest<Result<Guid>>
{
    public Guid IdCuenta { get; set; }
    public Guid IdCliente { get; set; }
    public int NumeroCuenta { get; set; }
    public decimal Saldo { get; set; }
    public bool Estado { get; set; }
    public string TipoDeCuenta { get; set; }

    public CreateAccountCommand(Guid idCuenta, Guid idCliente, int numeroCuenta, decimal saldo, bool estado, string tipoDeCuenta)
    {
        IdCuenta = idCuenta;
        IdCliente = idCliente;
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
        Estado = estado;
        TipoDeCuenta = tipoDeCuenta;
    }
}

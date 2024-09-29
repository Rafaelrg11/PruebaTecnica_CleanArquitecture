using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Accounts;
using PruebaTécnica.Domain.Accounts.Events;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Clientes.Events;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Cuenta;

public sealed class Account : Entity
{
    public Account(
        Guid id,
        Guid clienteId,
        NumberOfAccount numberOfAccount,
        Money saldo,
        AccountStatus accountStatus,
        TypeOfAccount typeOfAccount)
        :base(id)
    {     
        IdCliente = clienteId;
        NumeroCuenta = numberOfAccount;
        Saldo = saldo;
        Estado = accountStatus;
        TipoDeCuenta = typeOfAccount;
    }
    private Account()
    {
    }

    public Guid IdCuenta { get; private set; }
    public Guid IdCliente { get; private set; }
    public NumberOfAccount NumeroCuenta { get; private set; }
    public Money Saldo { get; private set; }
    public AccountStatus Estado { get; private set; }
    public TypeOfAccount TipoDeCuenta { get; private set; }
    public Client Cliente { get; private set; }
    public ICollection<Motion> movimientos { get; private set; } = new List<Motion>();

    public static Account Create(NumberOfAccount numberOfAccount, Money saldo, AccountStatus accountStatus, TypeOfAccount typeOfAccount, Guid clienteId)
    {
        var account = new Account(Guid.NewGuid(), clienteId, numberOfAccount, saldo, accountStatus, typeOfAccount);

        account.RaiseDomainEvent(new AccountCreatedDomainEvent(account.Id));

        return account;
    }
}

using Microsoft.EntityFrameworkCore;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Repository;

internal sealed class AccountRepository : Repository<Account>, IAccountRepository
{
    public AccountRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void CreateCuenta(Account cuenta)
    {
        _context.Add(cuenta);
        _context.SaveChanges();
    }

    public async Task<bool> DeleteCuenta(Account accountDTO, CancellationToken cancellationToken)
    {
        var account = await _context.Accounts.FindAsync(new object[] { accountDTO.IdCuenta }, cancellationToken);

        if (account == null)
        {
            return false;
        }

        // Luego, elimínala
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<Account> GetCuenta(Guid id, CancellationToken cancellationToken)
    {
        var account = await _context.Accounts.FindAsync(new object[] { id }, cancellationToken);
        if (account == null)
        {
            throw new KeyNotFoundException($"Account with ID {id} not found.");
        }
        return account;
    }

    public async Task<AccountDTO> GetCuenta2(Guid id, CancellationToken cancellationToken)
    {
        var account = await _context.Accounts
                    .Include(e => e.Cliente)
                    .Include(e => e.movimientos)
                    .FirstOrDefaultAsync(e => e.IdCuenta == id);

        if (account is null)
        {
            return null;
        }

        var accoundto = new AccountDTO
        {
            IdCliente = account.Id,
            IdCuenta = account.Id,
            NumeroCuenta = account.NumeroCuenta.Value,
            Saldo = account.Saldo.Amount,
            Estado = account.Estado.status,
            TipoDeCuenta = account.TipoDeCuenta.Value,
            Cliente = new Domain.DTOs.Client.ClientDTO2
            {
                IdCliente = account.Cliente.IdCliente,
                PersonaId = account.Cliente.PersonaId,
                Contraseña = account.Cliente.Contraseña.Value,
                Estado = account.Cliente.Estado.Value,
            },
            movimientos = account.movimientos.Select(e => new Domain.DTOs.Motion.MotionDTO2
            {
                IdMovimiento = e.IdMovimiento,
                CuentaId = e.CuentaId,
                TipoDeMovimiento = e.TipoDeMovimiento.Value,
                Valor = e.Valor.Amount,
                Saldo = e.Saldo.Amount,
                FechaDeMovimiento = (DateTime)e.FechaDeMovimiento
            }).ToList(),
        };

        return accoundto;
    }

    public async Task<IEnumerable<AccountDTO>> GetCuentas()
    {
        var account = await _context.Accounts
            .Select(e => new AccountDTO
            {
                IdCliente = e.IdCliente,
                IdCuenta = e.IdCuenta,
                NumeroCuenta = e.NumeroCuenta.Value,
                Saldo = e.Saldo.Amount,
                Estado = e.Estado.status,
                TipoDeCuenta = e.TipoDeCuenta.Value,
                Cliente = new Domain.DTOs.Client.ClientDTO2
                {
                    IdCliente = e.Cliente.IdCliente,
                    PersonaId = e.Cliente.PersonaId,
                    Contraseña = e.Cliente.Contraseña.Value,
                    Estado = e.Cliente.Estado.Value,
                },
                movimientos = e.movimientos.Select(e => new Domain.DTOs.Motion.MotionDTO2
                {
                    IdMovimiento = e.IdMovimiento,
                    CuentaId = e.CuentaId,
                    TipoDeMovimiento = e.TipoDeMovimiento.Value,
                    Valor = e.Valor.Amount,
                    Saldo = e.Saldo.Amount,
                    FechaDeMovimiento = e.FechaDeMovimiento
                }).ToList(),
            }).ToListAsync();
            

        return account;
    }

    public async Task UpdateCuenta(AccountDTO cuenta)
    {
        _context.Update(cuenta);
        _context.SaveChanges();
    }

    public async Task UpdateCuenta2(Guid cuenta)
    {
        _context.Update(cuenta);
        _context.SaveChanges();
    }
}

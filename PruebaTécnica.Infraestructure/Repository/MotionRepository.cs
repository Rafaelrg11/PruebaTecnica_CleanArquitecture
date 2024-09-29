using Microsoft.EntityFrameworkCore;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.DTOs.Account;
using PruebaTécnica.Domain.DTOs.Motion;
using PruebaTécnica.Domain.DTOs.Person;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PruebaTécnica.Infraestructure.Repository;

internal sealed class MotionRepository : Repository<Motion>, IMotionRepository
{
    private readonly IAccountRepository _accountRepository;
    public MotionRepository(ApplicationDbContext context, IAccountRepository accountRepository)
        : base(context)
    {
        _accountRepository = accountRepository;
    }

    public async Task CreateMovimiento(MotionDTO movimientos, CancellationToken cancellationToken)
    {
        if (movimientos == null)
        {
            throw new ArgumentNullException(nameof(movimientos));
        }

        var item = _accountRepository.GetCuenta2(movimientos.CuentaId, cancellationToken);

        var total = item.Result.Saldo + movimientos.Valor;
        if (total <= 0)
        {
            throw new Exception("Saldo insuficiente");
        }

        item.Result.Saldo = total;
        await _accountRepository.UpdateCuenta2(item.Result.IdCuenta);

        var movimiento = Motion.Create(new TypeOfMotion(movimientos.TipoDeMovimiento), 
            new Money(movimientos.Valor), new Money(movimientos.Saldo), movimientos.FechaDeMovimiento, movimientos.CuentaId);

        movimientos.IdMovimiento = movimiento.IdMovimiento;

        _context.Add(movimientos);
        _context.SaveChanges();
    }

    public void DeleteMovimiento(Motion id)
    {
        _context.Motions.Remove(id);
        _context.SaveChanges();
    }

    public async Task<Motion> GetMotion(Guid id, CancellationToken cancellationToken)
    {
        var motion = await _context.Motions
               .Include(c => c.Cuenta)
               .FirstOrDefaultAsync(e => e.IdMovimiento == id);

        if (motion == null)
        {
            return null;
        }

        await _context.Entry(motion)
            .Reference(c => c.Cuenta)
            .LoadAsync();

        return motion;
    }

    async Task<MotionDTO> IMotionRepository.GetMovimiento(Guid id, CancellationToken cancellationToken)
    {
        var motion = await _context.Motions
                    .Where(e => e.IdMovimiento == id)
                    .Select(e => new MotionDTO
                    {
                        IdMovimiento = e.IdMovimiento,
                        CuentaId = e.CuentaId,
                        FechaDeMovimiento = e.FechaDeMovimiento,
                        TipoDeMovimiento = e.TipoDeMovimiento.Value
                    })
                    .FirstOrDefaultAsync();

        return motion;
    }

    async Task<IEnumerable<MotionDTO>> IMotionRepository.GetMovimientos()
    {
        var result = await _context.Motions
            .Select(e => new MotionDTO
            {
                IdMovimiento = e.IdMovimiento,
                CuentaId = e.CuentaId,
                FechaDeMovimiento = e.FechaDeMovimiento,
                TipoDeMovimiento = e.TipoDeMovimiento.Value,
                Saldo = e.Saldo.Amount,
                Valor = e.Valor.Amount
            }).ToListAsync();

        return result;
    }

    async Task IMotionRepository.UpdateMovimiento(Motion movimientos)
    {
        _context.Motions.Update(movimientos);
        _context.SaveChanges();
    }
}

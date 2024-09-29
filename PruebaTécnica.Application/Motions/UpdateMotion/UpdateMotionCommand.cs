using MediatR;
using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.UpdateMotion;

public sealed class UpdateMotionCommand : IRequest<Result>
{
    public Guid IdMovimiento { get; set; }
    public Guid CuentaId { get; set; }
    public string TipoDeMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public DateTime FechaDeMovimiento { get; set; }

    public UpdateMotionCommand(Guid idMovimiento, Guid cuentaId, string tipoDeMovimiento, decimal valor, decimal saldo, DateTime fechaDeMovimiento)
    {
        IdMovimiento = idMovimiento;
        CuentaId = cuentaId;
        TipoDeMovimiento = tipoDeMovimiento;
        Valor = valor;
        Saldo = saldo;
        FechaDeMovimiento = fechaDeMovimiento;
    }
}

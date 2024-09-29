using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.DTOs.Motion;

public sealed class MotionDTO
{
    public Guid IdMovimiento { get; set; }
    public Guid CuentaId { get; set; }
    public string TipoDeMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public DateTime FechaDeMovimiento { get; set; }
}

using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.DTOs.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Movimientos;

public interface IMotionRepository
{
    Task<IEnumerable<MotionDTO>> GetMovimientos();
    Task<MotionDTO> GetMovimiento(Guid id, CancellationToken cancellationToken);
    Task<Motion> GetMotion(Guid id, CancellationToken cancellationToken);
    Task CreateMovimiento(MotionDTO movimientos, CancellationToken cancellationToken);
    Task UpdateMovimiento(Motion movimientos);
    void DeleteMovimiento(Motion id);
}

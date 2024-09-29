using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Movimientos;

public interface MotionInterface
{
    IEnumerable<Motion> GetMovimientos();
    IEnumerable<Motion> GetMovimiento(Guid id);
    public Task<Motion> CreateMovimiento(Motion movimientos);
    void UpdateMovimiento(int idMovimiento, Motion movimientos);
    void DeleteMovimiento(int id);
}

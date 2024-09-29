using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Motions;

public class WorthService
{
    private readonly IMotionRepository _motionRepository;

    public WorthService(IMotionRepository motionRepository)
    {
        _motionRepository = motionRepository;
    }

    public WorthDetails CalculateWorth(Motion motion)
    {
        var amountWorth = motion.Valor.Amount;
        var amountBalance = motion.Saldo.Amount;

        var amounthBalanceWorth = new Money(
            motion.Saldo.Amount + motion.Valor.Amount);

        return new WorthDetails(amounthBalanceWorth, motion.Valor);
    }
}

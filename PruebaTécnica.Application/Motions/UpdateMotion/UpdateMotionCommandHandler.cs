using MediatR;
using PruebaTécnica.Application.Persons.UpdatePerson;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.UpdateMotion;

public class UpdateMotionCommandHandler : IRequestHandler<UpdateMotionCommand, Result>
{
    private readonly IMotionRepository _motionRepository;

    public UpdateMotionCommandHandler(IMotionRepository motionRepository)
    {
        _motionRepository = motionRepository;
    }

    async Task<Result> IRequestHandler<UpdateMotionCommand, Result>.Handle(UpdateMotionCommand request, CancellationToken cancellationToken)
    {
        var persona = await _motionRepository.GetMotion(request.IdMovimiento, cancellationToken);

        if (persona == null)
        {
        }

        persona.UpdateTypeOfMotion(new TypeOfMotion(request.TipoDeMovimiento));
        persona.UpdateSaldo(new Money(request.Saldo));
        persona.UpdateValor(new Money(request.Valor));
        persona.UpdateFechaDeMovimiento(DateTime.UtcNow);

        await _motionRepository.UpdateMovimiento(persona);

        return Result.Success();
    }
}

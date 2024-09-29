using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using PruebaTécnica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.CreateMotion;

public class CreateMotionCommandHandler : IRequestHandler<CreateMotionCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMotionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateMotionCommand request, CancellationToken cancellationToken)
    {
        var idCuenta = request.Motion.CuentaId;
        var tipoDeMovimiento = new TypeOfMotion(request.Motion.TipoDeMovimiento);
        var valor = new Money(request.Motion.Valor);
        var saldo = new Money(request.Motion.Saldo);
        //var fechaDeMovimiento = new DateTime(request.Motion.FechaDeMovimiento.Ticks);
        var fechaDeMovimiento = DateTime.UtcNow;

        var newMotion = Motion.Create(tipoDeMovimiento,valor,saldo,fechaDeMovimiento, idCuenta);

        _unitOfWork.Add(newMotion);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(newMotion.Id);
    }
}

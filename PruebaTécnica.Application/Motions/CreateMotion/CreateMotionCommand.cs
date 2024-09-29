using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Motion;
using PruebaTécnica.Domain.Movimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.CreateMotion;

public sealed class CreateMotionCommand : IRequest<Result<Guid>>
{
    public MotionDTO2 Motion { get; }

    public CreateMotionCommand(MotionDTO2 motion)
    {
        Motion = motion ?? throw new ArgumentNullException(nameof(motion));
    }
}
    
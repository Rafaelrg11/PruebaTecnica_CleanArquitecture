using MediatR;
using PruebaTécnica.Application.Clients.CreateClient;
using PruebaTécnica.Application.Persons.GetPerson;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Motion;
using PruebaTécnica.Domain.DTOs.Person;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.GetMotion;

public class GetMotionCommandHandler : IRequestHandler<GetMotionCommand, Result<MotionDTO>>
{
    private readonly IMotionRepository _motionRepository;
    public GetMotionCommandHandler(IMotionRepository motionRepository)
    {
        _motionRepository = motionRepository;
    }

    async Task<Result<MotionDTO>> IRequestHandler<GetMotionCommand, Result<MotionDTO>>.Handle(GetMotionCommand request, CancellationToken cancellationToken)
    {
        var motion = await _motionRepository.GetMovimiento(request.Guid, cancellationToken);

        return motion;
    }
}

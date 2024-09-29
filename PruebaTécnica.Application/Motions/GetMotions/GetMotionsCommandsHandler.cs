using MediatR;
using PruebaTécnica.Application.Clients.GetClients;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Movimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.GetMotions;

public class GetMotionsCommandsHandler : IRequestHandler<GetMotionsCommands, Result>
{
    private readonly IMotionRepository _motionRepository;
    public GetMotionsCommandsHandler(IMotionRepository motionRepository)
    {
        _motionRepository = motionRepository;
    }
    public async Task<Result> Handle(GetMotionsCommands request, CancellationToken cancellationToken)
    {
        var motion = await _motionRepository.GetMovimientos();

        return Result.Success(motion);
    }
}

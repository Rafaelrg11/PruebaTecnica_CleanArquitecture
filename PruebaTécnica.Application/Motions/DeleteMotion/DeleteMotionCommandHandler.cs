using MediatR;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.DeleteMotion;

public class DeleteMotionCommandHandler : IRequestHandler<DeleteMotionCommand, bool>
{
    private readonly IMotionRepository _personaRepository;

    public DeleteMotionCommandHandler(IMotionRepository personaRepository)
    {
        _personaRepository = personaRepository;
    }

    async Task<bool> IRequestHandler<DeleteMotionCommand, bool>.Handle(DeleteMotionCommand request, CancellationToken cancellationToken)
    {
        var person = await _personaRepository.GetMotion(request.Guid, cancellationToken);

        if (person == null)
        {
            return false;
        }

        _personaRepository.DeleteMovimiento(person);

        return true;
    }

}

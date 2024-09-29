using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.DeleteMotion;

public class DeleteMotionCommand : IRequest<bool>
{
    public Guid Guid { get; }

    public DeleteMotionCommand(Guid guid)
    {
        Guid = guid;
    }

}

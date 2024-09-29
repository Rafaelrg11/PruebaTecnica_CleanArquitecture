using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Motion;
using PruebaTécnica.Domain.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.GetMotion
{
    public sealed class GetMotionCommand : IRequest<Result<MotionDTO>>
    {
        public Guid Guid { get; }

        public GetMotionCommand(Guid guid)
        {
            Guid = guid;
        }   
    }
}

using MediatR;
using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Motions.GetMotions;

public sealed class GetMotionsCommands : IRequest<Result>
{
}

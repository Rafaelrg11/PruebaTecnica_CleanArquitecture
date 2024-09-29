using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Persons.GetPerson;

public sealed class GetAccountCommand : IRequest<Result<Person>>
{
    public Guid Guid { get; }

    public GetAccountCommand(Guid guid)
    {
        Guid = guid;
    }
}

using MediatR;
using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Persons.DeletePerson;

public class DeleteAccountCommand : IRequest<bool>
{
public Guid Guid { get; }

public DeleteAccountCommand(Guid guid)
{
    Guid = guid;
}
}

using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTécnica.Domain.Persons;


namespace PruebaTécnica.Application.Persons.CreatePerson;

public sealed class CreatePersonCommand : IRequest<Result<Guid>>
{
    public PersonDTO Person { get; }

    public CreatePersonCommand(PersonDTO person)
    {
        Person = person ?? throw new ArgumentNullException(nameof(person));
    }
}

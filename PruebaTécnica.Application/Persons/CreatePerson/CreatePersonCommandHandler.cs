using MediatR;
using PruebaTécnica.Domain.Persons;
using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Persons.CreatePerson;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var name = new Name(request.Person.Name.value);
        var genero = new Genrer(request.Person.Genero.value);
        var edad = new Age(request.Person.Edad);
        var identificacion = new Identification(request.Person.Identificacion.value);
        var direccion = new Address(request.Person.Dirección.value);
        var telefono = new Phone(request.Person.Teléfono);

        var newPerson = PruebaTécnica.Domain.Persons.Person.Create(name, genero, edad, identificacion, direccion, telefono);

        _unitOfWork.Add(newPerson);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(newPerson.Id);
    }
}


using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Persons.UpdatePerson;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Result>
{
    private readonly IPersonRepository _personaRepository;

    public UpdatePersonCommandHandler(IPersonRepository personaRepository)
    {
        _personaRepository = personaRepository;
    }

    async Task<Result> IRequestHandler<UpdatePersonCommand, Result>.Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var persona = await _personaRepository.GetPersona(request.IdPersona, cancellationToken);

        if (persona == null)
        {
        }

        persona.UpdateName(new Name(request.Name));
        persona.UpdateGenero(new Genrer(request.Genero));
        persona.UpdateEdad(new Age(request.Edad));
        persona.UpdateIdentificacion(new Identification(request.Identificacion));
        persona.UpdateDirección(new Address(request.Dirección));
        persona.UpdateTeléfono(new Phone(request.Teléfono));

        await _personaRepository.UpdatePersona(persona);
        await _personaRepository.SaveChangesAsync();

        return Result.Success();
    }
}

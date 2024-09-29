using MediatR;
using PruebaTécnica.Application.Persons.GetPersons;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Persons.DeletePerson;

public class DeletePersonCommandHandler : IRequestHandler<DeleteAccountCommand,bool>
{
    private readonly IPersonRepository _personaRepository;

    public DeletePersonCommandHandler(IPersonRepository personaRepository)
    {
        _personaRepository = personaRepository;
    }

    async Task<bool> IRequestHandler<DeleteAccountCommand, bool>.Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var person = await _personaRepository.GetPersona(request.Guid, cancellationToken);

        if (person == null)
        {
            return false;
        }

        await _personaRepository.DeletePersona(person);
        await _personaRepository.SaveChangesAsync();

        return true;
    }
}

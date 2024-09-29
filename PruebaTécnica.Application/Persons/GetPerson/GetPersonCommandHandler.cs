using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.DTOs.Person;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Persons.GetPerson;

public class GetPersonCommandHandler : IRequestHandler<GetAccountCommand, Result<Person>>
{
    private readonly IPersonRepository _personaRepository;
    public GetPersonCommandHandler(IPersonRepository personRepository)
    {
        _personaRepository = personRepository;
    }

   async Task<Result<Person>> IRequestHandler<GetAccountCommand, Result<Person>>.Handle(GetAccountCommand request, CancellationToken cancellationToken)
   {
        var person = await _personaRepository.GetPersona(request.Guid, cancellationToken);

        return person;
   }
}

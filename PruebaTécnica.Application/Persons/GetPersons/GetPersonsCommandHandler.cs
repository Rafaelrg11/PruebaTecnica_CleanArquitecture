using MediatR;
using PruebaTécnica.Application.Clients.CreateClient;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Persons.GetPersons;

public class GetPersonsCommandHandler : IRequestHandler<GetAccountsCommand, Result>
{
    private readonly IPersonRepository _personaRepository;
    public GetPersonsCommandHandler(IPersonRepository personRepository )
    {
        _personaRepository = personRepository;
    }
    public async Task<Result> Handle(GetAccountsCommand request, CancellationToken cancellationToken)
    {
        var persons = await _personaRepository.GetPersonas();

        return Result.Success(persons);
    }
}

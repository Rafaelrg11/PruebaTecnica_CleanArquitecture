using MediatR;
using PruebaTécnica.Application.Persons.GetPerson;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.DTOs.Account;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.GetAccount;

public class GetAccountCommandHandler : IRequestHandler<GetAccountCommand, Result<AccountDTO>>
{
    private readonly IAccountRepository _personaRepository;

    public GetAccountCommandHandler(IAccountRepository personRepository)
    {
        _personaRepository = personRepository;
    }

    public async Task<Result<AccountDTO>> Handle(GetAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _personaRepository.GetCuenta2(request.Guid, cancellationToken);

        var accountTask = account;

        return account;
    }
}

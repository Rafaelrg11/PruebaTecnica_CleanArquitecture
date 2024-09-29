using MediatR;
using PruebaTécnica.Application.Persons.GetPersons;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.GetAccounts;

public class GetAccountsCommandHandler : IRequestHandler<GetAccountsCommand, Result>
{
    private readonly IAccountRepository _accountRepository;
    public GetAccountsCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Result> Handle(GetAccountsCommand request, CancellationToken cancellationToken)
    {
        var persons = await _accountRepository.GetCuentas();

        return Result.Success(persons);
    }
}

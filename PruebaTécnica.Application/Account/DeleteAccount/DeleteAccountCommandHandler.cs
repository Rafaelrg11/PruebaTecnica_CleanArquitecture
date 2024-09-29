using MediatR;
using PruebaTécnica.Application.Persons.DeletePerson;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.DeleteAccount;

public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, bool>
{
    private readonly IAccountRepository _personaRepository;

    public DeleteAccountCommandHandler(IAccountRepository personaRepository)
    {
        _personaRepository = personaRepository;
    }

    async Task<bool> IRequestHandler<DeleteAccountCommand, bool>.Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var person = await _personaRepository.GetCuenta(request.Guid, cancellationToken);

        if (person == null)
        {
            return false;
        }

        await _personaRepository.DeleteCuenta(person, cancellationToken);

        return true;
    }
}

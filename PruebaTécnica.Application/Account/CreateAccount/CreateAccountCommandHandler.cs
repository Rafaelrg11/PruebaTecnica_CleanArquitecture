using MediatR;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Accounts;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.Shared;

namespace PruebaTécnica.Application.Account.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountRepository _accountRepository;

    public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
    {
        _unitOfWork = unitOfWork;
        _accountRepository = accountRepository;
    }

    public async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var numeroDeCuenta = new NumberOfAccount(request.NumeroCuenta);
        var saldo = new Money(request.Saldo);
        var estado = new AccountStatus(request.Estado);
        var tipoDeCuenta = new TypeOfAccount(request.TipoDeCuenta);

        var account = PruebaTécnica.Domain.Cuenta.Account.Create(numeroDeCuenta, saldo, estado, tipoDeCuenta, request.IdCliente);

        _accountRepository.CreateCuenta(account);

        return Result.Success(account.IdCuenta);
    }
}

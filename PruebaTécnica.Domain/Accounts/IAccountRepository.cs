using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Cuentas;

public interface IAccountRepository
{
    Task<IEnumerable<AccountDTO>> GetCuentas();
    Task<Account> GetCuenta(Guid id, CancellationToken cancellationToken);
    Task<AccountDTO> GetCuenta2(Guid id, CancellationToken cancellationToken);
    void CreateCuenta(Account cuenta);
    Task UpdateCuenta2(Guid cuenta);
    Task UpdateCuenta(AccountDTO cuenta);
    Task<bool> DeleteCuenta(Account accountDTO, CancellationToken cancellationToken);
}

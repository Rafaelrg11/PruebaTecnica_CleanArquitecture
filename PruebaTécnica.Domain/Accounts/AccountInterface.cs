using PruebaTécnica.Domain.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Accounts;

public interface AccountInterface
{
    IEnumerable<Account> GetCuentas();
    IEnumerable<Account> GetCuenta(Guid id);
    public Account CreateCuenta(Account cuenta);
    void UpdateCuenta(int idCuenta, Account cuenta);
    void DeleteCuenta(int id);
}

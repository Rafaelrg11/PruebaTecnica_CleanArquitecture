using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Accounts
{
    public static class AccountErrors
    {
        public static Error NotFound = new(
           "Account.Found",
           "The account with the specified identifier was not found");      
    }
}

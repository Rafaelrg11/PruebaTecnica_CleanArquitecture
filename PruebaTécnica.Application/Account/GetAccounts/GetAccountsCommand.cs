﻿using MediatR;
using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Account.GetAccounts;

public sealed class GetAccountsCommand : IRequest<Result>
{
}

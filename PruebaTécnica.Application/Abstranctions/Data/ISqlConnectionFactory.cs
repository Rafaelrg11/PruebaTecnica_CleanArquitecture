﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Abstranctions.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}

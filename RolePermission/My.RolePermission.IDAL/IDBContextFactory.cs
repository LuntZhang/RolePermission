﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.RolePermission.IDAL
{
    public interface IDBContextFactory
    {
        DbContext CreateDbContext();
    }
}
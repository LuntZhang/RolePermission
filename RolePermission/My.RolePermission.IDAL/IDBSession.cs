using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace My.RolePermission.IDAL
{
    public partial interface IDBSession
    {
        DbContext Db { get; }
        bool SaveChanges();
        int ExecuteSql(string sql, params SqlParameter[] pars);
        List<T> ExecuteSelectQuery<T>(string sql, params SqlParameter[] pars);
    }
}

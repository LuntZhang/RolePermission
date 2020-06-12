using My.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using My.RolePermission.Model;

namespace My.RolePermission.DAL
{
    public class DbContextFactory : IDBContextFactory
    {
        public DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if(dbContext == null)
            {
                dbContext = new RolePermissionEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}

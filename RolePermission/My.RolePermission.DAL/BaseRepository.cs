using My.RolePermission.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using My.RolePermission.Model.SearchParam;

namespace My.RolePermission.DAL
{
    class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        /// <summary>
        /// EF上下文对象
        /// </summary>
        DbContext Db = new DbContextFactory().CreateDbContext();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Deleted;
            return true;

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntitiesAll(string entity)
        {
            return string.IsNullOrEmpty(entity) ? Db.Set<T>().AsQueryable() : Db.Set<T>().Include(entity).AsQueryable();
        }

        /// <summary>
        /// 对数据的分页查询
        /// </summary>
        /// <typeparam name="model">实体对象</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <param name="toalCount">总数</param>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<model>(int pageIndex, int pageSize, out int toalCount, Expression<Func<T, bool>> whereLambda, string orderby, bool? isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda.Compile()).AsQueryable();
            toalCount = temp.Count();
            // 排序
            if (isAsc.HasValue)
            {
                temp = isAsc.Value 
                    ?
                    temp = temp.OrderBy<T>(orderby).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize)
                    :
                    temp = temp.OrderByDescending<T>(orderby).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
    }
}

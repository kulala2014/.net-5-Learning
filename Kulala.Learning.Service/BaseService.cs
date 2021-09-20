using Kulala.EF.Model;
using Kulala.Learning.Common;
using Kulala.Learning.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kulala.Learning.Service
{
    public class BaseService : IBaseService
    {
        protected DbContext Context { get; private set; }

        public BaseService(DbContext context)
        {
            Context = context;
        }

        #region Query
        public T Find<T>(int id) where T : class
        {
            return Context.Set<T>().Find(id);
        }
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return Context.Set<T>().Where(funcWhere);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Context.Set<T>();
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            IQueryable<T> list = Context.Set<T>();

            if (funcWhere != null)
            {
                list = list.Where(funcWhere);
            }
            if (isAsc && funcOrderby != null)
            {
                list = list.OrderBy(funcOrderby);
            }
            else
            {
                list = list.OrderByDescending(funcOrderby);
            }

            PageResult<T> result = new PageResult<T>
            {
                DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = list.Count()
            };

            return result;

        }
        #endregion

        #region Insert
        public T Insert<T>(T t) where T : class
        {
            this.Context.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            Context.Set<T>().AddRange(tList);
            Commit();
            return tList;
        }
        #endregion

        #region Update
        /// <summary>
        /// 没有实现查询，直接跟新的，需要attach和state
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new ArgumentNullException("Upate item is null");

            Context.Set<T>().Attach(t);
            Context.Entry<T>(t).State = EntityState.Modified;
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }
        #endregion

        #region Delete
        public void Delete<T>(int id) where T : class
        {
            T t = this.Find<T>(id);//也可以附加
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Attach(t);
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
            }
            this.Context.Set<T>().RemoveRange(tList);
            this.Commit();
        }
        #endregion

        #region Other
        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public void Excute<T>(string sql, SqlParameter[] sqlParameters) where T : class
        {
            DbContextTransaction trans = null;

            try
            {
                trans = Context.Database.BeginTransaction();
                this.Context.Database.ExecuteSqlCommand(sql, sqlParameters);
                trans.Commit();
            }
            catch (Exception e)
            {
                trans?.Rollback();
                throw e;
            }
        }

        public IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] sqlParameters) where T : class
        {
            return this.Context.Database.SqlQuery<T>(sql, sqlParameters).AsQueryable();
        }

        public virtual void Dispose()
        {
            Context?.Dispose();
        }
        #endregion
    }
}

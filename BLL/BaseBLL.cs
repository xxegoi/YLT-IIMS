using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;

namespace BLL
{
    public partial class BaseBLL : IBLL.IBLL
    {
        protected IDAL.IDAL dal = new DAL.MsSqlDAL();

        public int Add<T>(T model) where T : class, new()
        {
            return dal.Add<T>(model);
        }

        public int BatchModify<T>(T model, Expression<Func<T, bool>> where, params string[] propertyes) where T : class, new()
        {
            return dal.BatchModidy<T>(model, where, propertyes);
        }

        public virtual int Delete<T>(T model) where T : class, new()
        {
            return dal.Delete<T>(model);
        }

        public virtual int DeleteByWhere<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return dal.DeleteByWhere<T>(where);
        }

        public int Modify<T>(T model, params string[] propertyes) where T : class, new()
        {
            return dal.Modify<T>(model, propertyes);
        }

        public List<T> Query<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return dal.Query<T>(where);
        }

        public List<T> QueryOrderBy<T, Tkey>(Expression<Func<T, bool>> where, Expression<Func<T,Tkey>> orderby) where T : class, new()
        {
            return dal.QueryOrderBy<T, Tkey>(where, orderby);
        }

        public List<T> QueryPage<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T,Tkey>> orderby) where T : class, new()
        {
            return dal.QueryPage<T, Tkey>(pageIndex, pageSize, where, orderby);
        }
    }
}

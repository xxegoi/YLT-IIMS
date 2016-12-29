using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IBLL
    {
        int Add<T>(T model)where T:class,new();

        int Delete<T>(T model)where T:class,new();

        int DeleteByWhere<T>(Expression<Func<T, bool>> where)where T:class,new();

        int Modify<T>(T model, params string[] propertyes)where T:class,new();

        int BatchModify<T>(T model, Expression<Func<T, bool>> where, params string[] propertyes)where T:class,new();

        List<T> Query<T>(Expression<Func<T, bool>> where)where T:class,new();

        List<T> QueryOrderBy<T, Tkey>(Expression<Func<T, bool>> where, Expression<Func<T,Tkey>> orderby)where T:class,new();

        List<T> QueryPage<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T,Tkey>> orderby)where T:class,new();
    }
}

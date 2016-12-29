using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IBLL
    {
        int Add<T>(T model);

        int Delete<T>(T model);

        int DeleteByWhere<T>(Expression<Func<T, bool>> where);

        int Modify<T>(T model, params string[] propertyes);

        int BatchModify<T>(T model, Expression<Func<T, bool>> where, params string[] propertyes);

        List<T> Query<T>(Expression<Func<T, bool>> where);

        List<T> QueryOrderBy<T, Tkey>(Expression<Func<T, bool>> where, Expression<Func<Tkey>> orderby);

        List<T> QueryPage<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<Tkey>> orderby);
    }
}

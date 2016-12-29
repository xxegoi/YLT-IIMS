using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IDAL
{
    public interface IDAL
    {
        /// <summary>
        /// 增加操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add<T>(T model) where T : class, new();
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        int Delete<T>(T model) where T : class, new();
        /// <summary>
        /// 根据条件删除记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        int DeleteByWhere<T>(Expression<Func<T, bool>> where) where T : class, new();
        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        int Modify<T>(T model,params string[] propertyes) where T : class, new();
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <param name="propertyes"></param>
        /// <returns></returns>
        int BatchModidy<T>(T model, Expression<Func<T, bool>> where, params string[] propertyes) where T : class, new();
        /// <summary>
        /// 查询记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        List<T> Query<T>(Expression<Func<T, bool>> where) where T : class, new();
        /// <summary>
        /// 查询并排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="IsDesc"></param>
        /// <returns></returns>
        List<T> QueryOrderBy<T,Tkey>(Expression<Func<T, bool>> where, Expression<Func<T,Tkey>> orderby,bool IsDesc=false) where T : class, new();
        /// <summary>
        /// 分页查询并排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tkey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="IsDesc"></param>
        /// <returns></returns>
        List<T> QueryPage<T,Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where,Expression<Func<T,Tkey>> orderby,bool IsDesc=false) where T : class, new();
    }
}

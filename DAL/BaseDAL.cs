using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;

namespace DAL
{
    public partial class BaseDAL : IDAL.IDAL
    {
        protected DbContext db;

        public int Add<T>(T model) where T : class, new()
        {
            db.Set<T>().Add(model);

            return db.SaveChanges();
        }

        public int BatchModidy<T>(T model, Expression<Func<T, bool>> where, params string[] propertyes) where T : class, new()
        {
            List<T> lst= db.Set<T>().Where(where).ToList<T>();

            if (lst.Count > 0)
            {
                List<PropertyInfo> t = typeof(T).GetProperties().ToList();

                foreach(string str in propertyes)
                {
                    PropertyInfo pi = t.FirstOrDefault(p => p.Name == str);
                    if (pi != null)
                    {
                        var value = pi.GetValue(model);
                        lst.ForEach(m =>{
                            pi.SetValue(m, value);
                            DbEntityEntry<T> entry = db.Entry(m);
                            entry.State = EntityState.Unchanged;

                            entry.Property(str).IsModified = true;
                        });
                    }
                    else
                    {
                        throw new Exception(string.Format("类：{0} 中不存在 {1} 的公开属性", typeof(T).Name, str));
                    }
                }
                return db.SaveChanges();
            }

            return 0;

        }

        public int Delete<T>(T model) where T : class, new()
        {
            db.Set<T>().Attach(model);
            db.Set<T>().Remove(model);

            return db.SaveChanges();
            
        }

        public int DeleteByWhere<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            List<T> lst = db.Set<T>().Where(where).ToList();

            lst.ForEach(p =>
            {
                db.Set<T>().Attach(p);

                db.Set<T>().Remove(p);
            });

            return db.SaveChanges();
        }

        public int Modify<T>(T model,params string[] propertyes) where T : class, new()
        {
            DbEntityEntry entry = db.Entry(model);
            entry.State = EntityState.Unchanged;

            foreach (string str in propertyes)
            {
                entry.Property(str).IsModified = true;
            }

            return db.SaveChanges();
        }

        public List<T> Query<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return db.Set<T>().Where(where).ToList();
        }

        public List<T> QueryOrderBy<T, Tkey>(Expression<Func<T, bool>> where, Expression<Func<T, Tkey>> orderby, bool IsDesc = false) where T : class, new()
        {
            if (IsDesc)
            {
                return db.Set<T>().Where(where).OrderByDescending(orderby).ToList();
            }
            return db.Set<T>().Where(where).OrderBy(orderby).ToList();
        }

        public List<T> QueryPage<T, Tkey>(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, Tkey>> orderby, bool IsDesc = false) where T : class, new()
        {
            if (IsDesc)
            {
                return db.Set<T>().Where(where).OrderByDescending(orderby).Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            return db.Set<T>().Where(where).OrderBy(orderby).Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}

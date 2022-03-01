using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolDB
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();

        T GetByKey(string Key);

        void Create(T entity);

        void Delete(T entity);

        void Delete(string key);

        void UpDate(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace API.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> SelectAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T SelectByID(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        void Insert(T entity);
        void Update(T oldEntity, T newEntity);
        void Delete(T entity);
    }
}

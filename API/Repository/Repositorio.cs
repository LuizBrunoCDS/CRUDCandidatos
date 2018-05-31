using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using API.Context;
using API.Interfaces;

namespace API.Repository
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        internal CRUDContext context;
        internal DbSet<T> dbSet;

        public Repositorio(CRUDContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public T SelectByID(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            foreach (var include in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(include);
            return query.FirstOrDefault(filter);
        }

        public IEnumerable<T> SelectAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            foreach (var include in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(include);
            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T oldEntity, T newEntity)
        {
            context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
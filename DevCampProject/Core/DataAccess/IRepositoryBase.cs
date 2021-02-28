using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IRepositoryBase<T> where T: class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        
    }
}

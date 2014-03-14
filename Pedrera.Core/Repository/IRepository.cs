using System;
using System.Collections.Generic;

namespace Pedrera.Core.Repository
{
    public interface IRepository<T, TId>
        where T : IIdentifiable<TId>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(Func<T, bool> predicate);
        T GetSingle(Func<T, bool> predicate);
        T GetSingle(TId id);
        T Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(TId id);
    }
}

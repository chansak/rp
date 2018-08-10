

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace RP.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        T GetById(long id);
        T GetById(string id);
        T GetById(Guid id);
		DateTime GetDbUtcDateTime();
    }
}


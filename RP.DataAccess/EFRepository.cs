using RP.Interfaces;
using RP.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RP.DataAccess
{
    public abstract class EFRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
        }

        private IDbSet<T> _objectset;
        public IDbSet<T> ObjectSet
        {
            get
            {
                if (_objectset == null)
                {
                    _objectset = _context.Set<T>();
                }
                return _objectset;
            }
        }

        public virtual IQueryable<T> All()
        {
            return ObjectSet.AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return ObjectSet.Where(expression);
        }

        public virtual void Add(T entity)
        {
            ObjectSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            ObjectSet.Remove(entity);
        }

        public virtual T GetById(int id)
        {
            return ObjectSet.Find(id);
        }

        public virtual T GetById(long id)
        {
            return ObjectSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return ObjectSet.Find(id);
        }

        public virtual T GetById(Guid id)
        {
            return ObjectSet.Find(id);
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }

        public DateTime GetDbUtcDateTime()
        {
            DateTime dt;
            using (var context = new RPContext())
            {
                dt = context.Database.SqlQuery<DateTime>("SELECT GETUTCDATE()").FirstOrDefault();
            }
            return dt;
        }
    }
}

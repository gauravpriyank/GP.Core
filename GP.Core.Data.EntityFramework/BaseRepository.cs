using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Data.EntityFramework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context;
        }

        public IQueryable<T> AsQueryable
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Save(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            T entity = _context.Set<T>().SingleOrDefault(predicate);

            if (entity == null)
                throw new ArgumentException("The predicate does not result in a single entity.", "predicate");

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _context.Entry(entity).State = EntityState.Modified;            
            _context.SaveChanges();
        }
    }
}

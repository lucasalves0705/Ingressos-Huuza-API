using Infrastructure.WorkUnit;
using Interface.Repository;
using Interface.WorkUnit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected HuuzaApiWorkUnit _context;

        public BaseRepository(IHuuzaApiWorkUnit context)
        {

            _context = (HuuzaApiWorkUnit)context;

        }

        public virtual List<T> ListAll() => this._context.Set<T>().ToList();

        public virtual List<T> FindAll(Expression<Func<T, bool>> expression) =>
            this._context.Set<T>().Where(expression).ToList();

        public virtual T Find(Expression<Func<T, bool>> expression) =>
            this._context.Set<T>().Where(expression).FirstOrDefault();

        public virtual void Insert(T entity) => this._context.Set<T>().Add(entity);

        public virtual void Update(T entity) => this._context.Set<T>().Update(entity);

        public virtual void Delete(T entity) => this._context.Set<T>().Remove(entity);

        public void Save()
        {

            this._context.SaveChanges();

        }

        public void Dispose()
        {
            this._context.Dispose();
        }

    }
}

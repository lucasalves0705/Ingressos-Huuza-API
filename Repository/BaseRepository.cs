using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data;
using Interface.Repository;

namespace Repository
{
    //public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    public abstract class BaseRepository<T> where T : class
    {

        protected huuzaapiContext _context;

        public BaseRepository(huuzaapiContext context)
        {
            
            _context = context;

        }   

        public List<T> ListAll() => this._context.Set<T>().ToList();

        public List<T> FindAll(Expression<Func<T, bool>> expression) => 
            this._context.Set<T>().Where(expression).ToList();

        public T Find(Expression<Func<T, bool>> expression) =>
            this._context.Set<T>().Where(expression).FirstOrDefault();

        public void Add(T entity) => this._context.Set<T>().Add(entity);

        public void Update(T entity) => this._context.Set<T>().Update(entity);

        public void Delete(T entity) => this._context.Set<T>().Remove(entity);

        public void Save()
        {
            
            this._context.SaveChanges();

        }

    }
}

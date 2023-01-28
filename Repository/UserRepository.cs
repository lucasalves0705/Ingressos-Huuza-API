using Data;
using Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class UserRepository : BaseRepository<User> //, UserRepository
    {

        private huuzaapiContext _huuzaapiContext;

        public UserRepository(huuzaapiContext context) : base(context)
        {

            _huuzaapiContext = new huuzaapiContext();

        }

        public void Create(User entity)
        {

            base.Add(entity);

        }

        public List<User> FindAll(Expression<Func<User, bool>> expression)
        {

            var result = base.FindAll(expression);

            return result;

        }

        public List<User> ListAll()
        {

            var result = base.ListAll();

            return result;

        }

    }
}

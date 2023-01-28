using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {

        void Create(User entity);

        List<User> FindAll(Expression<Func<User, bool>> expression);

        List<User> ListAll();

        List<Employeer> ListAllEmployers();

        List<Permission> ListPermissions();

        Employeer InsertEmployeer(Employeer entity);

        Login InsertLogin(Login entity);

        Employeer UpdateEmployeer(Employeer entity);

        Login UpdateLogin(Login entity);

        Employeer GetUserLoginCompany(Expression<Func<Employeer, bool>> expression);

        Login GetLogin(Expression<Func<Login, bool>> expression);

        Employeer GetEmployee(Expression<Func<Employeer, bool>> expression);

        Employeer FindEmployee(Expression<Func<Employeer, bool>> expression);

    }
}

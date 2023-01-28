using Data;
using Entity;
using Infrastructure.WorkUnit;
using Interface.Repository;
using Interface.WorkUnit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(IHuuzaApiWorkUnit context) : base(context)
        {
        }

        public void Create(User entity)
        {

            base.Insert(entity);

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

        public List<Employeer> ListAllEmployers()
        {

            var result = this._context.Employeers
                .Include(s => s.IdCompanyNavigation)
                .Include(s => s.IdLoginNavigation.IdUserNavigation)
                .Include(s => s.IdDepartamentNavigation)
                .Where(s => s.Active == true)
                .ToList();

            return result;

        }

        public List<Permission> ListPermissions()
        {

            var result = this._context.Permissions
                .Where(s => s.Active == true)
                .ToList();

            return result;

        }

        public Employeer InsertEmployeer(Employeer entity)
        {

            base._context.Set<Employeer>().Add(entity);

            return entity;

        }

        public Login InsertLogin(Login entity)
        {

            base._context.Set<Login>().Add(entity);

            return entity;

        }

        public Employeer UpdateEmployeer(Employeer entity)
        {

            base._context.Set<Employeer>().Update(entity);

            return entity;

        }

        public Login UpdateLogin(Login entity)
        {

            base._context.Set<Login>().Update(entity);

            return entity;

        }

        public Employeer GetUserLoginCompany(Expression<Func<Employeer, bool>> expression)
        {

            var result = this._context.Employeers
                .Include(s => s.IdLoginNavigation)
                .Where(expression)
                .FirstOrDefault();

            return result;

        }

        public Login GetLogin(Expression<Func<Login, bool>> expression)
        {

            var result = this._context.Logins
                .Where(expression)
                .FirstOrDefault();

            return result;

        }

        public Employeer GetEmployee(Expression<Func<Employeer, bool>> expression)
        {

            var result = this._context.Employeers
                .Where(expression)
                .FirstOrDefault();

            return result;

        }

        public Employeer FindEmployee(Expression<Func<Employeer, bool>> expression)
        {

            var result = this._context.Employeers
                .Include(s => s.IdLoginNavigation)
                .Include(s => s.IdLoginNavigation.IdUserNavigation)
                .Include(s => s.IdLoginNavigation.IdPermissionNavigation)
                .Include(s => s.IdDepartamentNavigation)
                .Where(expression)
                .FirstOrDefault();

            return result;

        }

    }
}

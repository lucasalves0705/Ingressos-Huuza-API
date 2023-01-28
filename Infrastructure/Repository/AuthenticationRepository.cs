using Entity;
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
    public class AuthenticationRepository : BaseRepository<Login>, IAuthenticationRepository
    {

        public AuthenticationRepository(IHuuzaApiWorkUnit context) : base(context)
        {
        }

        public Permission GetPermissionUser(Expression<Func<Permission, bool>> expression)
        {

            var result = this._context.Permissions
                .Where(expression)
                .FirstOrDefault();

            return result;

        }

        public Login FindAuthenticate(Expression<Func<Login, bool>> expression)
        {

            var result = this._context.Logins
                .Include(s => s.IdUserNavigation)
                .Where(expression)
                .FirstOrDefault();

            return result;

        }

    }
}

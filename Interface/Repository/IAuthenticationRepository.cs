using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IAuthenticationRepository: IBaseRepository<Login>
    {

        Permission GetPermissionUser(Expression<Func<Permission, bool>> expression);

        Login FindAuthenticate(Expression<Func<Login, bool>> expression);

    }
}

using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IRoomRepository : IBaseRepository<Room>
    {

        Employeer GetEmployeer(Expression<Func<Employeer, bool>> expression);

        Room FindAsNoTracking(Expression<Func<Room, bool>> expression);

    }
}

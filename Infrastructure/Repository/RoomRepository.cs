using Entity;
using Interface.Repository;
using Interface.WorkUnit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {

        public RoomRepository(IHuuzaApiWorkUnit context) : base(context)
        {
        }

        public Employeer GetEmployeer(Expression<Func<Employeer, bool>> expression)
        {

            var result = this._context.Employeers
                .Include(s => s.IdCompanyNavigation)
                .Where(expression)
                .FirstOrDefault();

            return result;

        }

        public Room FindAsNoTracking(Expression<Func<Room, bool>> expression)
        {

            var result = this._context.Rooms
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();

            return result;

        }

    }
}

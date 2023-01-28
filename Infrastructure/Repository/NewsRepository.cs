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
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {

        public NewsRepository(IHuuzaApiWorkUnit context) : base(context)
        {
        }

        public List<News> ListNowShowing(Expression<Func<News, bool>> expression)
        {

            var result = this._context.News
                .Where(expression)
                .Include(x => x.IdEvent)
                .ToList();

            return result;

        }

    }
}

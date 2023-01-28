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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(IHuuzaApiWorkUnit context) : base(context)
        {
        }

        public Category FindAsNoTracking(Expression<Func<Category, bool>> expression)
        {

            var result = this._context.Categories
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefault();

            return result;

        }

    }
}

using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {

        Category FindAsNoTracking(Expression<Func<Category, bool>> expression);

    }
}

using Entity;
using Interface.Repository;
using Interface.WorkUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class DepartamentRepository : BaseRepository<Departament>, IDepartamentRepository
    {

        public DepartamentRepository(IHuuzaApiWorkUnit context) : base(context)
        {
        }

    }
}

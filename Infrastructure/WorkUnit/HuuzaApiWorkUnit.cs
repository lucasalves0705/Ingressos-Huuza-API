using Data;
using Interface.WorkUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WorkUnit
{
    public class HuuzaApiWorkUnit : huuzaapiContext, IHuuzaApiWorkUnit
    {

        public HuuzaApiWorkUnit() : base()
        {
        }

        public void FinalizeTransaction()
        {

            this.SaveChanges();

        }

    }
}

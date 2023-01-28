using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace Fabric
{
    public abstract class BaseFabric<E> : IDisposable
    {

        public E objReturn { get; set; }
        public Container _Container { get; set; }

        public BaseFabric()
        {

            this._Container = new Container();

        }

        public abstract void Dispose();

    }
}

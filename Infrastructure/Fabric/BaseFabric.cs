using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Fabric
{
    public abstract class BaseFabric<T> : IDisposable
    {

        public T workUnitReturn { get; set; }

        public Container _container { get; set; }

        protected T InstanceObject { get; set; }

        public BaseFabric()
        {

            this._container = new Container();

        }

        public abstract T GetInstance();

        public abstract void Dispose();
    }
}

using Domain;
using Infrastructure.Repository;
using Infrastructure.WorkUnit;
using Interface.Domain;
using Interface.Repository;
using Interface.WorkUnit;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Fabric
{
    public class DepartamentFabric : BaseFabric<IDepartamentDomain>
    {

        public DepartamentFabric()
        {

            this.Create();

        }

        public void Create()
        {

            var lifestyle = Lifestyle.Transient;

            base._container.Register<IHuuzaApiWorkUnit, HuuzaApiWorkUnit>(lifestyle);

            base._container.Register<IDepartamentRepository, DepartamentRepository>(lifestyle);

            base._container.Register<IErrorDomain, ErrorDomain>(lifestyle);

            base._container.Register<IDepartamentDomain, DepartamentDomain>(lifestyle);

            base._container.Verify(VerificationOption.VerifyOnly);

            base.InstanceObject = base._container.GetInstance<IDepartamentDomain>();

        }

        public override IDepartamentDomain GetInstance()
        {

            return base.InstanceObject;

        }

        public override void Dispose()
        {

            base.InstanceObject.Dispose();

            base._container.Dispose();

        }

    }
}

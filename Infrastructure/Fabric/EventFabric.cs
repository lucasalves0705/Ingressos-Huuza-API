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
    public class EventFabric : BaseFabric<IEventDomain>
    {

        public EventFabric()
        {

            this.Create();

        }

        public void Create()
        {

            var lifestyle = Lifestyle.Transient;

            base._container.Register<IHuuzaApiWorkUnit, HuuzaApiWorkUnit>(lifestyle);
            
            base._container.Register<IEventRepository, EventRepository>(lifestyle);

            base._container.Register<IErrorDomain, ErrorDomain>(lifestyle);

            base._container.Register<IEventDomain, EventDomain>(lifestyle);

            base._container.Verify(VerificationOption.VerifyOnly);

            base.InstanceObject = base._container.GetInstance<IEventDomain>();

        }

        public override IEventDomain GetInstance()
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

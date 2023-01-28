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
    public class RoomFabric : BaseFabric<IRoomDomain>
    {

        public RoomFabric()
        {

            this.Create();

        }

        public void Create()
        {

            var lifestyle = Lifestyle.Transient;

            base._container.Register<IHuuzaApiWorkUnit, HuuzaApiWorkUnit>(lifestyle);
            
            base._container.Register<IRoomRepository, RoomRepository>(lifestyle);

            base._container.Register<IErrorDomain, ErrorDomain>(lifestyle);

            base._container.Register<IRoomDomain, RoomDomain>(lifestyle);

            base._container.Verify(VerificationOption.VerifyOnly);

            base.InstanceObject = base._container.GetInstance<IRoomDomain>();

        }

        public override IRoomDomain GetInstance()
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

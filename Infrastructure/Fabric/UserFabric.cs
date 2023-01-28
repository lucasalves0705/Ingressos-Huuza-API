using Domain;
using Infrastructure.Repository;
using Infrastructure.WorkUnit;
using Interface.Domain;
using Interface.Repository;
using Interface.WorkUnit;
using SimpleInjector;

namespace Infrastructure.Fabric
{
    public class UserFabric : BaseFabric<IUserDomain>
    {

        public UserFabric() : base()
        {

            this.Create();

        }

        public void Create()
        {
            var lifestyle = Lifestyle.Transient;

            base._container.Register<IHuuzaApiWorkUnit, HuuzaApiWorkUnit>(lifestyle);

            base._container.Register<IUserRepository, UserRepository>(lifestyle);

            base._container.Register<IErrorDomain, ErrorDomain>(lifestyle);

            base._container.Register<IUserDomain, UserDomain>(lifestyle);

            base._container.Verify(VerificationOption.VerifyOnly);

            base.InstanceObject = base._container.GetInstance<IUserDomain>();

        }

        public override IUserDomain GetInstance()
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

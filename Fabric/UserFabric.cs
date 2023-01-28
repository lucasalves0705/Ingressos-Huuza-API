using Interface.Domain;
using Domain;
using Repository;
using Interface.Repository;
using Domain;
using SimpleInjector;
using Data;

namespace Fabric
{
    public class UserFabric : BaseFabric<IUserDomain>
    {

        public UserFabric()
        {
            var context = new huuzaapiContext();

            base._Container.Register<IErrorDomain, ErrorDomain>(Lifestyle.Transient);
            base._Container.Register<IErrorDomain, ErrorDomain>(Lifestyle.Transient);
            base._Container.Register<IUserRepository, UserRepository>(Lifestyle.Transient, context);
            base._Container.Register<IUserDomain, UserDomain>(Lifestyle.Transient);
            base.objReturn = base._Container.GetInstance<IUserDomain>();

        }

        public override void Dispose()
        {

            base.objReturn = null;

            base._Container.Dispose();

        }

    }
}
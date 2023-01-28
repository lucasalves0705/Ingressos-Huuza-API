using DataTransferObject;
using Infrastructure.Fabric;

namespace HuuzaAPI.Models
{
    public class AuthenticationModel
    {

        public ReturnDTO<LoginDTO> Authenticate(LoginDTO login, int type)
        {

            var result = new ReturnDTO<LoginDTO>();

            using (var authenticationFabric = new AuthenticationFabric())
            {

                result = authenticationFabric.GetInstance().Find(login, type);

            }
            
            return result;

        }

        public ReturnDTO<PermissionDTO> GetPermissionUser(int id)
        {

            var result = new ReturnDTO<PermissionDTO>();

            using(var authenticationFabric = new AuthenticationFabric())
            {

                result = authenticationFabric.GetInstance().GetPermissionUser(id);

            }

            return result;

        }

    }
}

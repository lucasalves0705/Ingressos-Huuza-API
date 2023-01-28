using Data;
using DataTransferObject;
using Infrastructure.Fabric;

namespace HuuzaAPI.Models
{
    public class UserModel
    {

        public ReturnDTO<List<UserDTO>> ListAll()
        {

            var result = new ReturnDTO<List<UserDTO>>();

            using (var fabric = new UserFabric())
            {

                result = fabric.GetInstance().ListAll();

            }

            return result;

        }

        public ReturnDTO<List<ListEmployersDTO>> ListAllEmployers()
        {

            var result = new ReturnDTO<List<ListEmployersDTO>>();

            using (var fabric = new UserFabric())
            {

                result = fabric.GetInstance().ListAllEmployers();

            }

            return result;

        }

        public ReturnDTO<List<PermissionDTO>> ListPermissions()
        {

            var result = new ReturnDTO<List<PermissionDTO>>();

            using (var fabric = new UserFabric())
            {

                result = fabric.GetInstance().ListPermissions();

            }

            return result;

        }

        public ReturnDTO<List<UserDTO>> FindAll()
        {

            var result = new ReturnDTO<List<UserDTO>>();

            using (var fabric = new UserFabric())
            {

                result = fabric.GetInstance().FindAll(x => x.Active == true);

            }

            return result;

        }

        public ReturnDTO<UserDTO> Find(int idUser)
        {

            var result = new ReturnDTO<UserDTO>();

            using(var fabric = new UserFabric())
            {

                result = fabric.GetInstance().Find(x => x.Id == idUser && x.Active == true);

            }

            return result;

        }

        public ReturnDTO<CreateEmployersDTO> FindEmployee(int idUser)
        {

            var result = new ReturnDTO<CreateEmployersDTO>();

            using (var fabric = new UserFabric())
            {

                result = fabric.GetInstance().FindEmployee(idUser);

            }

            return result;

        }

        public ReturnDTO<EmployeerDTO> EmployersSave(CreateEmployersDTO obj)
        {

            var result = new ReturnDTO<EmployeerDTO>();

            using (var fabric = new UserFabric())
            {

                result = fabric.GetInstance().EmployersSave(obj);

            }

            return result;

        }

    }
}

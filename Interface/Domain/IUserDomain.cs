using DataTransferObject;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Domain
{
    public interface IUserDomain : IDisposable
    {

        ReturnDTO<EmployeerDTO> EmployersSave(CreateEmployersDTO entity);

        ReturnDTO<UserDTO> Find(Expression<Func<User, bool>> expression);

        ReturnDTO<CreateEmployersDTO> FindEmployee(int idUser);

        ReturnDTO<List<UserDTO>> FindAll(Expression<Func<User, bool>> expression);

        ReturnDTO<List<UserDTO>> ListAll();

        ReturnDTO<List<ListEmployersDTO>> ListAllEmployers();

        ReturnDTO<List<PermissionDTO>> ListPermissions();

    }
}

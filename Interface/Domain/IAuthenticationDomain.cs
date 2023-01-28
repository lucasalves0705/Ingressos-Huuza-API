using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Domain
{
    public interface IAuthenticationDomain : IDisposable
    {

        ReturnDTO<LoginDTO> Find(LoginDTO login, int type);

        ReturnDTO<PermissionDTO> GetPermissionUser(int id);

    }
}

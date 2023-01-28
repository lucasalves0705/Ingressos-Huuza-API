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
    public interface IRoomDomain : IDisposable
    {

        ReturnDTO<RoomDTO> Save(RoomDTO entity);

        ReturnDTO<RoomDTO> Find(int id);

        ReturnDTO<List<RoomDTO>> ListAll(int id);

        ReturnDTO<RoomDTO> Inactivate(int idRoom);

    }
}

using DataTransferObject;
using Infrastructure.Fabric;

namespace HuuzaAPI.Models
{
    public class RoomModel
    {

        public ReturnDTO<List<RoomDTO>> ListAll(int id)
        {

            var result = new ReturnDTO<List<RoomDTO>>();

            using(var fabric = new RoomFabric())
            {

                result = fabric.GetInstance().ListAll(id);

            }

            return result;

        }

        public ReturnDTO<RoomDTO> Find(int id)
        {

            var result = new ReturnDTO<RoomDTO>();

            using (var fabric = new RoomFabric())
            {

                result = fabric.GetInstance().Find(id);

            }

            return result;

        }

        public ReturnDTO<RoomDTO> Save(RoomDTO obj)
        {

            var result = new ReturnDTO<RoomDTO>();

            using(var fabric = new RoomFabric())
            {

                result = fabric.GetInstance().Save(obj);

            }

            return result;

        }

        public ReturnDTO<RoomDTO> Inactivate(int id)
        {

            var result = new ReturnDTO<RoomDTO>();

            using (var fabric = new RoomFabric())
            {

                result = fabric.GetInstance().Inactivate(id);

            }

            return result;

        }

    }

}

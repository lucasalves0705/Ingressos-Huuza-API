using DataTransferObject;
using Infrastructure.Fabric;

namespace HuuzaAPI.Models
{
    public class DepartamentModel
    {

        public ReturnDTO<List<DepartamentDTO>> ListAll()
        {

            var result = new ReturnDTO<List<DepartamentDTO>>();

            using (var fabric = new DepartamentFabric())
            {

                result = fabric.GetInstance().ListAll();

            }

            return result;

        }

    }
}

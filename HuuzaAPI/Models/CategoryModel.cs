using DataTransferObject;
using Infrastructure.Fabric;

namespace HuuzaAPI.Models
{
    public class CategoryModel
    {

        public ReturnDTO<List<CategoryDTO>> ListAll()
        {

            var result = new ReturnDTO<List<CategoryDTO>>();

            using (var fabric = new CategoryFabric())
            {

                result = fabric.GetInstance().ListAll();

            }

            return result;

        }

        public ReturnDTO<List<CategoryDTO>> ListActive()
        {

            var result = new ReturnDTO<List<CategoryDTO>>();

            using (var fabric = new CategoryFabric())
            {

                result = fabric.GetInstance().ListActive();

            }

            return result;

        }

        public ReturnDTO<CategoryDTO> Find(int id)
        {

            var result = new ReturnDTO<CategoryDTO>();

            using (var fabric = new CategoryFabric())
            {

                result = fabric.GetInstance().Find(id);

            }

            return result;

        }

        public ReturnDTO<CategoryDTO> Save(CategoryDTO category)
        {

            var result = new ReturnDTO<CategoryDTO>();

            using (var fabric = new CategoryFabric())
            {

                result = fabric.GetInstance().Save(category);

            }

            return result;

        }

        public ReturnDTO<CategoryDTO> Inactivate(int id)
        {

            var result = new ReturnDTO<CategoryDTO>();

            using (var fabric = new CategoryFabric())
            {

                result = fabric.GetInstance().Inactivate(id);

            }

            return result;

        }

    }
}

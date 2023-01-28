using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Domain
{
    public interface ICategoryDomain : IDisposable
    {

        ReturnDTO<List<CategoryDTO>> ListAll();

        ReturnDTO<List<CategoryDTO>> ListActive();

        ReturnDTO<CategoryDTO> Find(int id);

        ReturnDTO<CategoryDTO> Save(CategoryDTO category);

        ReturnDTO<CategoryDTO> Inactivate(int id);
    }
}

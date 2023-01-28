using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class UserDTO
    {

        public int Id { get; set; }
        public int IdUserType { get; set; }
        public string Cpf { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

    }
}

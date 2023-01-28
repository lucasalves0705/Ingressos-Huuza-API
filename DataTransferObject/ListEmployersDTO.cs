using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class ListEmployersDTO
    {

        public int Id { get; set; }
        public int IdLogin { get; set; }
        public int IdCompany { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; } = null!;
        public string Departament { get; set; } = null!;
        public string NameCompany { get; set; } = null!;

    }
}

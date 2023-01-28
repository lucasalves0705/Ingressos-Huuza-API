using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class EmployeerDTO
    {

        public int Id { get; set; }
        public int IdLogin { get; set; }
        public int IdDepartament { get; set; }
        public int IdCompany { get; set; }
        public bool Active { get; set; }

    }
}

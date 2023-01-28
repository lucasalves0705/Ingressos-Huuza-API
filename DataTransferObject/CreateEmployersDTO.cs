using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class CreateEmployersDTO
    {

        public int IdEmployee { get; set; }

        public int IdLogin { get; set; }

        public int IdResponsible { get; set; }

        public int IdDepartament { get; set; }

        public int IdCompany { get; set; }

        public bool ActiveEmployee { get; set; }
        
        public int IdUser { get; set; }
        
        public int IdPermission { get; set; }

        public string Cpf { get; set; } = null!;

        public string Name { get; set; } = null!;
        
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;
        
        public bool ActiveUser { get; set; }

    }
}

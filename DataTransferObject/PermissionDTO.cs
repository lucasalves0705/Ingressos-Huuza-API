using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class PermissionDTO
    {

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

    }
}

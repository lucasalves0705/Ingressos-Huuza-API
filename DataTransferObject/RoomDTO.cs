using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class RoomDTO
    {

        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int IdLogin { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MaxSeats { get; set; }
        public bool? Active { get; set; }

    }
}

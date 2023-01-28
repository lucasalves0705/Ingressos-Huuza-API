using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public  class EventsRoomSaveDTO
    {

        public int Id { get; set; }
        public int IdEvents { get; set; }
        public int IdRoom { get; set; }
        public int IdLogin { get; set; }
        public int IdCompany { get; set; }
        public string? NameEvent { get; set; } = null!;
        public string? NameRoom { get; set; } = null!;
        public DateTime DatePresetion { get; set; }
        public int Duration { get; set; }
        public bool Active { get; set; }

    }
}

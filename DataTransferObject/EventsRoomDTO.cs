using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public  class EventsRoomDTO
    {

        public int Id { get; set; }
        public int IdEvents { get; set; }
        public int IdRoom { get; set; }
        public DateTime DatePresetion { get; set; }
        public int Duration { get; set; }
        public bool Active { get; set; }

    }
}

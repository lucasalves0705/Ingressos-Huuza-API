using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class EventsRoom
    {
        public EventsRoom()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int IdEvents { get; set; }
        public int IdRoom { get; set; }
        public DateTime DatePresetion { get; set; }
        public int Duration { get; set; }
        public bool Active { get; set; }

        public virtual Event IdEventsNavigation { get; set; } = null!;
        public virtual Room IdRoomNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Room
    {
        public Room()
        {
            EventsRooms = new HashSet<EventsRoom>();
            Seats = new HashSet<Seat>();
        }

        public int Id { get; set; }
        public int IdCompany { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MaxSeats { get; set; }
        public bool? Active { get; set; }

        public virtual Company IdCompanyNavigation { get; set; } = null!;
        public virtual ICollection<EventsRoom> EventsRooms { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}

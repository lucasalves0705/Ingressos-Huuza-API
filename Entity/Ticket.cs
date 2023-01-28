using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int IdSeat { get; set; }
        public int IdMovieRoom { get; set; }
        public int IdSale { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

        public virtual EventsRoom IdMovieRoomNavigation { get; set; } = null!;
        public virtual Sale IdSaleNavigation { get; set; } = null!;
    }
}

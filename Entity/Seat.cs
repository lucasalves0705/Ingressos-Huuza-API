using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Seat
    {
        public int Id { get; set; }
        public int IdRoom { get; set; }
        public int IdStatus { get; set; }

        public virtual Room IdRoomNavigation { get; set; } = null!;
    }
}

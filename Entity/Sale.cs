using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Sale
    {
        public Sale()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int IdLogin { get; set; }
        public DateTime Data { get; set; }
        public bool Active { get; set; }

        public virtual Login IdLoginNavigation { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
